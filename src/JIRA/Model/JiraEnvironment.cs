﻿using System.Text.Json.Serialization;

namespace DevExLead.Integrations.JIRA.Model
{
    public class JiraEnvironment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}