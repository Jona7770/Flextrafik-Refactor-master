﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Domain;
using System.IO;

namespace DataAccess
{
    public class CSVExportToCallList
    {
        public void CreateFile(Encoding encoding, string filePath, List<Offer> winningOfferList)
        {
            try
            {
                // Delete the file if it exists.
                if (File.Exists(filePath))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(filePath);
                }
                // Create the file.
                using (StreamWriter streamWriter = new StreamWriter(@filePath, true, encoding)) 
                {
                    streamWriter.WriteLine("Nummer" + ";" + "Virksomhedsnavn" + ";" + "Navn" + ";" +"Vedståede v. 2" + ";" + "Vedståede v. 3" + ";" + "Vedståede v. 5" + ";" + "Vedståede v. 6" + ";"+ "Vedståede v. 7" + ";" + "Vundne v. 2"+";" + "Vundne v. 3" + ";" + "Vundne v. 5" +";" + "Vundne v. 6" +";" + "Vundne v. 7");
                    List<Offer> offersToPrint = new List<Offer>(); 

                    foreach (Offer offer in winningOfferList)
                    {
                        if (!offersToPrint.Any(obj => obj.UserID == offer.UserID))
                        {
                            offersToPrint.Add(offer);
                            streamWriter.WriteLine(offer.OfferReferenceNumber + ";" + offer.Contractor.CompanyName + ";" + offer.Contractor.ManagerName + ";" + offer.Contractor.NumberOfType2PledgedVehicles + ";" + offer.Contractor.NumberOfType3PledgedVehicles + ";" + offer.Contractor.NumberOfType5PledgedVehicles + ";" + offer.Contractor.NumberOfType6PledgedVehicles + ";" + offer.Contractor.NumberOfType7PledgedVehicles + ";" + offer.Contractor.NumberOfWonType2Offers + ";" + offer.Contractor.NumberOfWonType3Offers + ";" + offer.Contractor.NumberOfWonType5Offers + ";" + offer.Contractor.NumberOfWonType6Offers + ";" + offer.Contractor.NumberOfWonType7Offers + ";");

                        }
                    }
                    streamWriter.Close();
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(s); WHUUUUUUUUUUT!!! ÐÐ!
                    }
                }
            }
            catch(Exception)
            {
                throw new Exception("Filen blev ikke gemt");
            }
        }
            
        
    }
}