# SilentAuctionApplication
ASP.NET C#

In this project, we have developed a Silent Auction app for the Baby Fold's Festival of Trees event. This web-based app is to allow participants to bid on donated items (trees, wreaths, etc.) with proceeds going to help the needy.

We have covered below use cases in this application which are developed using ASP.NET C#, Ajax, JavaScript, AjaxControl Toolkit,
SOAP Web Services and client with to-and-fro communication with Microsoft sql server database.

1. Sign-in User

2. Sign up Account: Details: Name (first and last), address, home phone number, cell phone number (might have both phone numbers, might have one, need a way to distinguish which the number is so we know if we can text the number)
Differing user permissions (allowing Steering Committee members to complete data entry for their own items without complete access). 4 levels of permissions: Public, Designer/Donor, Steering Committee, Admin.

3. Enter auction item (for a given event) item name, donor/designer, approximate value, minimum bid amount, angel price (when applicable, see Special Notes section below)) Designer/donor, Steering Committee, Admin can all do this

4. Search/Edit Info - buyer last name, phone numbers including cell and home (admin only) item category/number

5. Print bid sheets - item name, some type of identifier (category/number), minimum bid and space for individuals to fill out name/bid/phone number sponsor names for the event added at the top of the sheets

6. Print invoices (to successful bidders) 
Must group by buyer (not by item so that each buyer will have all their items on one invoice/receipt). Must include successful bid amount, approximate value (for tax purposes)

7. Email invoices/receipts (to successful bidders) (see above)
Report/View paid vs. unpaid items, sold vs. unsold items (items with no bids) Export selected information to Excel
Might include buyer, item name, item category/number, winning bid, buyer address, buyer phone, paid/unpaid 

I am still working on some pieces of this application and will add/update whenever any change is made.

Nikunj Ratnaparkhi
