using Fuse.Data.Common;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuse.AspNet.Identity
{
    public class IdentityUser : Entity<int>, IUser<int>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        public override bool IsNew { get; set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public override int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether email confirmed.
        /// </summary>
        /// <value>
        ///   <c>true</c>c> if the email is confirmed, default is <c>false</c>>.
        /// </value>
        public virtual bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>
        /// A random value that should change whenever a users credentials have changed (password changed, login removed).
        /// </value>
        public virtual string SecurityStamp { get; set; }


        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether phone number confirmed.
        /// </summary>
        /// <value>
        /// <c>true</c> if phone number is confirmed; otherwise, <c>false</c>.
        /// </value>
        public virtual bool PhoneNumberConfirmed { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [two factor enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [two factor enabled]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the lockout end date UTC.
        /// </summary>
        /// <value>
        /// DateTime in UTC when lockout ends, any time in the past is considered not locked out.
        /// </value>
        public virtual DateTime? LockoutEndDateUtc { get; set; }


        /// <summary>
        /// Is lockout enabled for this user.
        /// </summary>
        public virtual bool LockoutEnabled { get; set; }
        
        /// <summary>
        /// Used to record failures for the purposes of lockout
        /// </summary>
        /// <value>
        /// The access failed count.
        /// </value>
        public virtual int FailedLoginCount { get; set; }

        /// <summary>
        /// Gets or sets the perishable token.
        /// </summary>
        /// <value>
        /// The perishable token.
        /// </value>
        public virtual Guid PerishableToken { get; set; }

        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        /// <value>
        /// The last login date.
        /// </value>
        public virtual DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public virtual byte StatusId { get; set; }
    }
}
