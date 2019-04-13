using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class holds all Order informaton for orders submitted through Default.Asax 
/// </summary>
public class OrderInformation
{
    public OrderInformation()
    {
        
        
    }
    private String mLoyaltyNumber;
    private String mSelectedStore;
    private Dictionary<String, Int32> SelectedProductQuantity = new Dictionary<string, int>();
    private String mOrderStatus;
    private String mOrderNumber;

    // Create Accessor Methods for private properties

    public string LoyaltyNumber
    {
        get { return mLoyaltyNumber; }
        set { mLoyaltyNumber = value; }
    }
    public string SelectedStore
    {
        get { return mSelectedStore; }
        set { mSelectedStore = value; }
    }
    public string OrderNumber
    {
        get { return mOrderNumber; }
        set { mOrderNumber = value; }

    }
    public string OrderStatus
    {
        get { return mOrderStatus; }
        set { mOrderStatus = value; }
    }
    
    
}