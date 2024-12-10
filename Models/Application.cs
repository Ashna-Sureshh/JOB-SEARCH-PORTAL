using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOBSEARCHPORTAL.Models
{
    
        public class Application
        {
        public int ApplicationId { get; set; }
        public int uid { get; set; }  // User ID
        public int jid { get; set; }  // Job ID
        public string Resume { get; set; }  // Path to the resume file
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        
    }
    

}