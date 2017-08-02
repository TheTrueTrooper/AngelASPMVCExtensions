#region WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: June 23,2017
//Project Goal: Encapsulate code for reuse and make more readable.
//File Goal: To add a Validation for files that are uploaded to the server (Number of files)
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: ASP.net
//  Writer/Publisher: Microsoft
//  Link: https://www.asp.net/
//  },
//  {
//  Name: stackoverflow.com question 40199870 Answer 1
//  Writer/Publisher: Stephen Muecke answered Oct 23 '16 at 5:58
//  Link: https://stackoverflow.com/questions/40199870/how-to-validate-file-type-of-httppostedfilebase-attribute-in-asp-net-mvc-4?answertab=votes#tab-top
//  }
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AngelASPExtentions.ExtraValidationAttributes.Files
{
    /// <summary>
    /// This property is to add file data annotation for the maximum number of files acceptable
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    class MaxFileNumAttribute : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// the Maximum number of files
        /// </summary>
        private int _ValidFileNum { get; set; }

        /// <summary>
        /// Creates an annotation for the maximum number of files allowed
        /// </summary>
        /// <param name="Num">the maximum number of files allowed</param>
        public MaxFileNumAttribute(int Num)
        {
            _ValidFileNum = Num;
            ErrorMessage = "There are too many files. The max number of files is " + Num;
        }

        /// <summary>
        /// returns if the validation was successful
        /// </summary>
        /// <param name="value">the object in question to validate</param>
        /// <param name="validationContext"> the context at which it was provided</param>
        /// <returns>ValidationResult</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<HttpPostedFileBase> files = value as IEnumerable<HttpPostedFileBase>;
            if (files?.Count() > _ValidFileNum)
            {
                return new ValidationResult(ErrorMessageString);
            }
            return ValidationResult.Success;
        }

        /// <summary>
        /// Creates the ModelClientValidationRule to give to the client
        /// </summary>
        /// <param name="metadata">The Model's Metadata</param>
        /// <param name="context">The Controller's Context</param>
        /// <returns>List of IEnumerable ModelClientValidationRule</returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule()
            {
                ValidationType = "maxfilenumber",
                ErrorMessage = ErrorMessageString
            };
            rule.ValidationParameters.Add("size", _ValidFileNum);
            yield return rule;
        }
    }
}
