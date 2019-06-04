using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using NLog;

namespace WiiBalanceScale
{
    public class DataWriter
    {

        private Subject trackMeta;

        private StreamWriter streamWriter;
        private CsvWriter csvWriter;
        private string path;

        public DataWriter(Subject subject, string path)
        {
            trackMeta = subject;
            this.path = path;

            streamWriter = new StreamWriter(GetFilePath());
            csvWriter = new CsvWriter(streamWriter);
            writeHeader();
        }


        public string GetFileName()
        {
            return string.Format("stabilo-balanceboard-{0}-{1}.csv", trackMeta.Name, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
        }
        
        private string GetFilePath()
        {
            return Path.Combine(path, GetFileName());
        }

        private void writeHeader()
        {
            streamWriter.WriteLine(string.Format("# Start time (local): {0} ", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
            streamWriter.WriteLine(string.Format("# Experiment type: {0} ", trackMeta.ExperimentType));
            streamWriter.WriteLine(string.Format("# Subject name: {0} ", trackMeta.Name));
            streamWriter.WriteLine(string.Format("# Sex: {0}", trackMeta.Sex));
            streamWriter.WriteLine(string.Format("# Height (cm): {0}", trackMeta.Height));
            streamWriter.WriteLine(string.Format("# Weight (kg): {0}", trackMeta.Weight));
            streamWriter.WriteLine(string.Format("# Track notes: {0}", trackMeta.Notes));
            
        }

        public void Log(IList<Record> records)
        {
            csvWriter.Flush();
            csvWriter.WriteRecords<Record>(records);
            csvWriter.Flush();
            csvWriter.Dispose();
            streamWriter.Dispose();

        }
    }

}
