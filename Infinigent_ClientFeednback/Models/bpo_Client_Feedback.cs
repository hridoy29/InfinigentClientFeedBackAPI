//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infinigent_ClientFeednback.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bpo_Client_Feedback
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public int ResponseRatingId { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string OthersValue { get; set; }
    
        public virtual ad_Rating ad_Rating { get; set; }
        public virtual ad_User ad_User { get; set; }
        public virtual bpo_Client_Questionaires bpo_Client_Questionaires { get; set; }
    }
}
