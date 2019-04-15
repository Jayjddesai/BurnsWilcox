// ReSharper disable InconsistentNaming

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BurnsWilcoxCLP.Models.Common
{
    public class Enums
    {
        public enum PolicyWizardEnum
        {
            [Description("LOB")]
            LOB = 0,
            [Description("Party")]
            Party = 1,
            [Description("Insured")]
            Insured = 2,
            [Description("Locations")]
            Locations = 3,
            [Description("Term")]
            Term = 4,
            [Description("Quote")]
            Quote = 5,
            [Description("Issue")]
            Issue = 6,
            [Description("Endorse")]
            Endorse = 7,
            [Description("Renew")]
            Renew = 8,
            [Description("Cancel")]
            Cancel = 9
        }
        public enum NotifyType
        {

            /// <summary>
            /// Success Enum Value setting.
            /// </summary>
            [Display(Name = "Success")]
            [Description("Success")]
            Success = 1,

            /// <summary>
            /// Error Enum Value setting.
            /// </summary>
            [Display(Name = "Error")]
            [Description("Error")]
            Error = 0
        }
    }


    #region Enum Extension
    public static class EnumExtension
    {
        /// <summary>
        /// The get description.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetDescription(this Enum element)
        {
            var type = element.GetType();
            var memberInfo = type.GetMember(Convert.ToString(element));
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return Convert.ToString(element);
        }

        /// <summary>
        /// The get string value
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetStringValuefromEnum(Enum value)
        {
            string output = null;
            var type = value.GetType();
            {
                // Look for our 'StringValueAttribute' in the field's custom attributes
                var fi = type.GetField(Convert.ToString(value));
                var attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    output = attrs[0].Value;
                }
            }

            return output;
        }
    }

    public sealed class StringValueAttribute : Attribute
    {
        /// <summary>
        /// The _value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public StringValueAttribute(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value
        {
            get { return _value; }
        }
    }
    #endregion
}
