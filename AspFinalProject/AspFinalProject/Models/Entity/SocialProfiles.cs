using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspFinalProject.Models.Entity
{
    public class SocialProfiles : BaseEntity
    {
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Skype { get; set; }
        public string LinkIN { get; set; }
    }
}