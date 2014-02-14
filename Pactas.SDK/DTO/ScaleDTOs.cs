using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pactas.SDK.DTO
{
    public enum TariffVersionLockStatus
    {
        NotLocked = 0,
        Locked = 1,
        LockedAndActive = 2,
    }

    public class ScaleValidation
    {
        public static ValidationResult ValidateDiscountScale(DiscountScaleDTO dto)
        {
            if (dto != null)
            {
                if (dto.Items == null || dto.Items.Count == 0)
                    return new ValidationResult("DiscountScale must not be empty!");
                if (dto.Items[0].From != 0)
                    return new ValidationResult("DiscountScale must start w/ From = 0.");

                // Verify 'From' is strictly monotonic
                var lastFrom = dto.Items[0].From;
                for (int i = 1; i < dto.Items.Count; ++i)
                {
                    if (dto.Items[i].From <= lastFrom)
                        return new ValidationResult(string.Format("DiscountScale's 'From' must increase strictly monotonically, but index {0}'s From ({1}) <= preceding value", i, dto.Items[i].From));
                }
            }

            return ValidationResult.Success;
        }

        public static ValidationResult ValidatePriceScale(PriceScaleDTO dto)
        {
            if (dto != null)
            {
                if(dto.Items == null || dto.Items.Count == 0)
                    return new ValidationResult("PriceScale must not be empty!");
                if(dto.Items[0].From != 0)
                    return new ValidationResult("PriceScale must start w/ From = 0.");

                // Verify 'From' is strictly monotonic
                var lastFrom = dto.Items[0].From;
                for(int i = 1; i < dto.Items.Count; ++i)
                {
                    if(dto.Items[i].From <= lastFrom)
                        return new ValidationResult(string.Format("PriceScale's 'From' must increase strictly monotonically, but index {0}'s From ({1}) <= preceding value", i, dto.Items[i].From));
                }
            }

            return ValidationResult.Success;
        }
    }

    public class PriceScaleItemDTO
    {
        public bool IsBucketPrice { get; set; }
        public decimal From { get; set; }
        public decimal Value { get; set; }
    }

    public class DiscountScaleItemDTO
    {
        public decimal From { get; set; }
        [Range(0, 100)]
        public decimal Value { get; set; }
    }

    //public abstract class ScaleDTO
    //{
    //    public bool IsCumulative { get; set; }
    //    public List<ScaleItemDTO> Items { get; set; }
    //}

    [CustomValidation(typeof(ScaleValidation), "ValidatePriceScale")]
    public class PriceScaleDTO //: ScaleDTO 
    {
        public bool IsCumulative { get; set; }
        public List<PriceScaleItemDTO> Items { get; set; }
    }

    [CustomValidation(typeof(ScaleValidation), "ValidateDiscountScale")]
    public class DiscountScaleDTO //: ScaleDTO
    {
        public bool IsCumulative { get; set; }
        public decimal BasePricePerUnit { get; set; }
        public List<DiscountScaleItemDTO> Items { get; set; }
    }
}
