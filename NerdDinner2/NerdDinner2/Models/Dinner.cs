using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner2.Models
{
    [Bind(Include="Title,Description,EventDate,Address,Country,ContactPhone,Latitude,Longitude")]
    public partial class Dinner
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }    
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Title))
            {
                yield return new RuleViolation("Title Required", "Title");
            }
            if (String.IsNullOrEmpty(Description))
            {
                yield return new RuleViolation("Description Required", "Description");
            }
            if (String.IsNullOrEmpty(HostedBy))
            {
                yield return new RuleViolation("HostedBy Required", "HostedBy");
            }
            if (String.IsNullOrEmpty(ContactPhone))
            {
                yield return new RuleViolation("Phone Number Required", "ContactPhone");
            }
            if (String.IsNullOrEmpty(Address))
            {
                yield return new RuleViolation("Address Required", "Address");
            }
            if (String.IsNullOrEmpty(Country))
            {
                yield return new RuleViolation("Country Required", "Country");
            }

            if(!PhoneValidator.IsValidNumber(ContactPhone, Country))
            {
                yield return new RuleViolation("Phone Number does not match country", "ContactPhone");
            }

            yield break;
        }

        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (!IsValid)
            {
                throw new ApplicationException("Rule violations pervent saving");
            }
        }
    }

    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}