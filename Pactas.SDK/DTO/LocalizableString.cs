using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Pactas.SDK.DTO
{
    public class LocalizableString : Dictionary<string, string>
    {
        // private const Language LanguageDefault = Language._c;
        private const string LanguageDefault = "_c";

        public LocalizableString()
        {
        }

        public LocalizableString(string defaultValue)
        {
            Add(LanguageDefault, defaultValue);
        }

        //public string GetTranslation(Language language)
        //{
        //    if (ContainsKey(language.ToString()))
        //        return this[language.ToString()];
        //    else
        //        return GetDefaultValue();
        //}

        [Pure]
        public string GetTranslation(string locale)
        {
            if (locale != null && locale.Length >= 2)
            {
                if (ContainsKey(locale))
                    return this[locale];
                else if (ContainsKey(locale.Substring(0, 2)))
                    return this[locale.Substring(0, 2)];
            }
            
            return GetDefaultValue();
        }

        // Why isn't DefaultValue a property?
        public void SetDefaultValue(string value)
        {
            this[LanguageDefault] = value;
        }

        public string GetDefaultValue()
        {
            if (ContainsKey(LanguageDefault))
                return this[LanguageDefault];
            return null;
        }

        static public explicit operator LocalizableString(string value)
        {
            return new LocalizableString(value);
        }

        static public implicit operator string(LocalizableString value)
        {
            return value.GetDefaultValue();
        }
    }
}
