using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// This class holds all Order informaton for orders submitted through Default.Asax 
/// </summary>
public class OrderInformation
{
    // multiple constructors to allow a class to be instantiated with or without the order number
    /// <summary>
    /// Constructor to instantiate a class with loyalty and store number. 
    /// </summary>
    /// <param name="loyaltyNumber"></param>
    /// <param name="selectedStore"></param>
    public OrderInformation( string loyaltyNumber, string selectedStore)
    {
        // Allow a class to be instantiated with a loyaltyNumber and selectedStore
        this.loyaltyNumber = loyaltyNumber;
        this.selectedStore = selectedStore;
        this.orderNumber = orderNumber;
        this.orderStatus = orderStatus;
    }
    /// <summary>
    /// Constructor to allow a class to be instantiated with a loyalty number, store they selected as well as order number and status. 
    /// </summary>
    /// <param name="loyaltyNumber"></param>
    /// <param name="selectedStore"></param>
    /// <param name="OrderNumber"></param>
    /// <param name="OrderStatus"></param>
   
    public OrderInformation(string loyaltyNumber, string selectedStore, string OrderNumber, string OrderStatus)
    {
        this.loyaltyNumber = loyaltyNumber;
        this.selectedStore = selectedStore;
        this.orderNumber = orderNumber;
        this.orderStatus = orderStatus;
    }
    private String mLoyaltyNumber;
    private String mSelectedStore;
    private Dictionary<String, Int32> SelectedProductQuantity = new Dictionary<string, int>();
    private String mOrderStatus;
    private String mOrderNumber;

    // Create Accessor Methods for private properties

    public string loyaltyNumber
    {
        get { return mLoyaltyNumber; }
        set
        {
            if (mLoyaltyNumber.Length != 0)
            {
                double number;
                // Use tryparse to verify the values are digits and not letters. 
                bool success = Double.TryParse(mLoyaltyNumber,out number);
                if (success)
                {
                    mLoyaltyNumber = value;
                }
                else
                {
                    // Do not allow a loyalty number to be returned  
                    Console.WriteLine("Loyalty number must only contain Digits.");
                }
            }
            else
            {
              Console.WriteLine("You must enter a Loyalty Number.");
            }
        }
    }
    public string selectedStore
    {
        get { return mSelectedStore; }
        set { mSelectedStore = value; }
    }
    public string orderNumber
    {
        get { return mOrderNumber; }
        set { mOrderNumber = value; }

    }
    public string orderStatus
    {
        get { return mOrderStatus; }
        set { mOrderStatus = value; }
    }
}