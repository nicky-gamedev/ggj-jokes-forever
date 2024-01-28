using System;
using Newtonsoft.Json;

public class DialogData
{
     [JsonProperty("dialog_key")] 
     public string Key { get; private set;}
     [JsonProperty("dialog_type")] 
     public string Type { get; private set;}
     [JsonProperty("dialog_text")] 
     public string Text { get; private set;}
     [JsonProperty("dialog_appear_time")] 
     public float AppearTime { get; private set;}
     [JsonProperty("index")] 
     public int index { get; private set;}
}