using System;

// representing https://www.kaiterra.com/dev/#devices-all-devices-get

namespace webapp.Data
{
    public class KaiterraTelemetry
    {
        public string Param {get;set;}
        public string Units{get;set;}
        public int Span {get;set;}

        public KaiterraTelemetryPoint[] Points {get;set;}
    }
}
