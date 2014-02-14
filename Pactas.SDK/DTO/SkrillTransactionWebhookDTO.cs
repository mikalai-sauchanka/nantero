using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Globalization;

namespace Pactas.SDK.DTO
{
    public enum SkrillTransactionStatus
    {
        failed = -2,
        cancelled = -1,
        pending = 0,
        finished = 1,
        processed = 2
    }

    public class SkrillTransactionWebhookDTO
    {
        public SkrillTransactionWebhookDTO(NameValueCollection collection, string responseData)
        {
            foreach (var p in GetType().GetProperties())
            {
                var value =  collection[p.Name];
                switch (p.Name)
                {
                    case "mb_amount":
                    case "amount":
                        value = string.IsNullOrWhiteSpace(value) ? "0" : value;
                        p.SetValue(this, Decimal.Parse(value,CultureInfo.InvariantCulture), null);
                        break;
                    case "status":
                        this.status = (SkrillTransactionStatus)Enum.Parse(typeof(SkrillTransactionStatus), value, true);
                        break;
                    default:
                        var type = p.PropertyType;
                        if ((value != null) && (type.Name == "String"))
                            p.SetValue(this, value, null);
                        break;
                }
            }

            Collection = collection;
            ResponseData = responseData;
        }

        public string ResponseData { get; set; }

        public string rec_payment_type { get; set; }
        public string rec_payment_id { get; set; }
        public string pay_to_email { get; set; }
        public string pay_from_email { get; set; }
        public string merchant_id { get; set; }
        public string customer_id { get; set; }
        public string transaction_id { get; set; }
        public string mb_transaction_id{ get; set; }
        public decimal mb_amount{ get; set; }
        public string mb_currency { get; set; }
        public SkrillTransactionStatus status { get; set; }
        public string failed_reason_code { get; set; }
        public string md5sig { get; set; }
        public string sha2sig { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string payment_type { get; set; }
        public string merchant_fields { get; set; }
        public string pactas_trn_id { get; set; }

        public string CalculatedMd5Sig { get; set; }
        private NameValueCollection Collection { get; set; }

        public bool ValidateMd5Sig(string secretWordMd5)
        {
            CalcMd5Sig(secretWordMd5);
            return CalculatedMd5Sig.Equals(md5sig);
        }

        private string CalcMd5Sig(string secretWordMd5)
        {
            var sb = new StringBuilder();
            sb.Append(Collection["merchant_id"]);
            sb.Append(Collection["transaction_id"]);
            sb.Append(secretWordMd5);
            sb.Append(Collection["mb_amount"]);
            sb.Append(Collection["mb_currency"]);
            sb.Append(Collection["status"]);

            byte[] bytes = MD5.Create().ComputeHash(new ASCIIEncoding().GetBytes(sb.ToString()));
            sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            CalculatedMd5Sig = sb.ToString().ToUpper();
            return CalculatedMd5Sig;
        }

    }
}
