using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Dropbox.Models {
    
    public class DropboxObject {

        #region Properties

        public JObject JObject { get; }

        #endregion

        #region Constructors

        protected DropboxObject(JObject obj) {
            JObject = obj;
        }

        #endregion

    }

}