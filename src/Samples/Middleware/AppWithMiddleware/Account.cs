namespace AppWithMiddleware;

public class Account
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }
    public decimal MinimumThreshold { get; set; }
}

#region sample_AccountLookupMiddleware

// This is *a* way to build middleware in Wolverine by basically just
// writing functions/methods. There's a naming convention that
// looks for Before/BeforeAsync or After/AfterAsync

#endregion

#region sample_using_deliver_within_attribute

// The attribute directs Wolverine to send this message with
// a "deliver within 5 seconds, or discard" directive

#endregion