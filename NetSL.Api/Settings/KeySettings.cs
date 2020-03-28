namespace NetSL.Api.Settings {
    public class KeySettings : IKeySettings {
        public string ReseplanerareKey {get;set;}
        public string StorningsinformationKey {get;set;}
        public string RealtidsinformationKey {get;set;}
        public string TrafiklageKey {get;set;}

        public KeySettings(string trafiklageKey, string reseplanerareKey, string storningsinformationKey, string realtidsinformationKey) {
            this.TrafiklageKey = trafiklageKey;
            this.ReseplanerareKey = reseplanerareKey;
            this.StorningsinformationKey = storningsinformationKey;
            this.RealtidsinformationKey = realtidsinformationKey;
        }
    }
}