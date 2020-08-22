using System;

// representing https://www.kaiterra.com/dev/#devices-all-devices-get

namespace webapp.Data
{

    public class KaiterraTelemetryPoint {
        public DateTime ts { get; set; }
        public float value {get;set;}
    }
    public class KaiterraTelemetry
    {

        public string Param {get;set;}
        public string Units{get;set;}
        public int Span {get;set;}

        public KaiterraTelemetryPoint[] Points {get;set;}
    }
}
