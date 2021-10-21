using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace UC1createContact
{
    public class UC1csvHandler
    {
        public static void ImplementCSVDataHandler()
        {
            string importFilePath = @"L:\BridgeLabz Solution\Dot net\September\New Batch\Oct\19-10-2021\AddressBook\UC1createContact\UC1createContact\Address.CSV";
            string exportFilePath = @"L:\BridgeLabz Solution\Dot net\September\New Batch\Oct\19-10-2021\AddressBook\UC1createContact\UC1createContact\ExportCsv.CSV";
            string exportJsonFilePath = @"L:\BridgeLabz Solution\Dot net\September\New Batch\Oct\19-10-2021\AddressBook\UC1createContact\UC1createContact\ExportJson.json";
            using (var reader= new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<UC1AddressData>().ToList();
                Console.WriteLine("Read data successfully from Address.CSV");
                foreach(UC1AddressData addressdata in records)
                {
                    Console.WriteLine(addressdata.firstname);
                    Console.WriteLine(addressdata.lastname);
                    Console.WriteLine(addressdata.address);
                    Console.WriteLine(addressdata.city);
                    Console.WriteLine(addressdata.state);
                    Console.WriteLine(addressdata.code);
                    Console.WriteLine(addressdata.phonenumber);
                    Console.WriteLine(addressdata.email);
                }
                Console.WriteLine("********************************************");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                    Console.WriteLine("Export Successfully CSv file");
                }
                Console.WriteLine("**********************************************");
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw= new StreamWriter(exportJsonFilePath))
                using (JsonTextWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}
