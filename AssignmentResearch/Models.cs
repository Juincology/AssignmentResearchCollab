using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentResearch.Models
{
    public class ResourceData
    {
        
        public List<non_portable> non_portable { get; set; }
        public List<Portable> Portable { get; set; }
        public List<booking> Booking { get; set; }
        //public List<Useraccount> user { get; set; }
        public List<string> resourceType { get; set; }
    }

   public abstract class GamingEquipment
    {
        public string NameOfGamingEquipments

        { get; set; }
        public string ResourceId

        { get; set; }
        public double RentalPrice
        {
            get; set;
        }
        public string DeliveryMode

        { get; set; }
    }
    public class Portable : GamingEquipment
    {
        public string sizeOfScreen

        { get; set; }

        public double quantityOfCartridges

        { get; set; }

        public string CartridgeName

        { get; set; }

        public bool touchScreenFunction

        { get; set; }
    }
    public class non_portable : GamingEquipment
    {
        public int quantityOfCables

        { get; set; }

        public string TypeOfCable

        { get; set; }

        public string Accessories

        { get; set; }
    }
    public class booking
    {
        public string bookingDate { get; set; }
        public int bookingid { get; set; }
    }

    public class resourceType
    {
        public string resourceTypeName { get; set; }
    }

    public class Useraccount
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int cardNum { get; set; }
        public DateTime expiryDate { get; set; }
        public string paymentType { get; set; }
        public string address { get; set; }
    }
}
