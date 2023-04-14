namespace MVVMLight.Models
{
    public struct Setting
    {
        public Setting() : this("Null", "Null") { }

        public Setting(string name, string value)
        {
            SettingName = name;
            SettingValue = value;
        }

        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
