using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string datatype = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            StreamWriter writer = new StreamWriter(filename);

            List<GroupData> groups = new List<GroupData>();
            List<AddressData> address = new List<AddressData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(bBaseTest.GenerateRandomString(10))
                {
                    GroupHeader = bBaseTest.GenerateRandomString(100),
                    GroupFooter = bBaseTest.GenerateRandomString(100)
                });
            }

            for (int i = 0; i < count; i++)
            {
                address.Add(new AddressData(bBaseTest.GenerateRandomString(10), bBaseTest.GenerateRandomString(10))
                {
                    MiddleName = bBaseTest.GenerateRandomString(10),
                    Address = bBaseTest.GenerateRandomString(10),
                    Phone2 = bBaseTest.GenerateRandomString(10),
                    NickName = bBaseTest.GenerateRandomString(10),
                    Address2 = bBaseTest.GenerateRandomString(10),
                    Mail1 = bBaseTest.GenerateRandomString(10),
                    WorkPhone = bBaseTest.GenerateRandomString(10),
                    HomePhone = bBaseTest.GenerateRandomString(10),
                    Mail2 = bBaseTest.GenerateRandomString(10),
                    Mail3 = bBaseTest.GenerateRandomString(10)
                });
            }

            //if (format == "csv")
            //{
            //        writGroupsToCsvFile(groups, writer);
            //        writContactsToCsvFile(groups, writer);
            //}
            //else 
            if (format == "xml")
            {
                if (datatype == "group")
                {
                    writeGroupsToXMLFile(groups, writer);
                }
                else if (datatype == "contacts")
                {
                    writeContactsToXMLFile(address, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized datatype: " + datatype);
                }

            }
            else if (format == "json")
            {
                if (datatype == "group")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else if (datatype == "contacts")
                {
                    writeContactsToJsonFile(address, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized datatype: " + datatype);
                }
            }
            else
            {
                    System.Console.Out.Write("Unrecognized format: " + format);
            }
            writer.Close();
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            int row = 1;
            foreach(GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.GroupName;
                sheet.Cells[row, 2] = group.GroupHeader;
                sheet.Cells[row, 3] = group.GroupHeader;
                row++;
            }
            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);
            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.GroupName, group.GroupHeader, group.GroupFooter));
            }
        }
        static void writeGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void writeContactsToXMLFile(List<AddressData> addresses, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<AddressData>)).Serialize(writer, addresses);
        }
        static void writeContactsToJsonFile(List<AddressData> addresses, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(addresses, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
