using AssignmentResearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentResearch
{

    public static class bookingCart
    {
        public static void initializeBookingCart()
        {
            bookingitems = new List<CartItem>();
        }
        public static List<CartItem> bookingitems { get; set; }
        //make a new booking cart for gaming equipment
        public static void booking_cart()
        {
            bookingitems = new List<CartItem>();
        }
        public static void addbooking(CartItem inbookingitems)
        {
            bookingitems.Add(inbookingitems);
        }
        public static void deletebooking(CartItem inbookingitems)
        {
            bookingitems.Remove(inbookingitems);
        }
        public static List<CartItem> getbookingitems()
        {
            return bookingitems;
        }
    }

    public class CartItem : GamingEquipment
    {
        public CartItem(GamingEquipment inResource)
        {
            this.NameOfGamingEquipments = inResource.NameOfGamingEquipments;
            this.ResourceId = inResource.ResourceId;
            this.RentalPrice = inResource.RentalPrice;
            this.DeliveryMode = inResource.DeliveryMode;
            
        }


        //public double CalculatePrice(DateTime S, DateTime E)
        //{
        //    double cartItemPrice;
        //    TimeSpan totalDate = E - S;
        //    cartItemPrice = totalDate.Days * this.price;
        //    this.itemPrice = cartItemPrice;
        //    return cartItemPrice;
        //}

    }
}
