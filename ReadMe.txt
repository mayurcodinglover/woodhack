
>> Table: Cart

CartId
UserId
ProductID
SubCatID

>> Table: OrderMaster

OrderID
UserID
TotalPrice

>> Table: OrderItem

OrderItemId
OrderId
ProductId
SubCategoryId
ProductPrice
DiscountedPrice

>> Table: Address

AddressId
Address 1
Address 2
City
State
ZipCode


SELECT * FROM Users >> AddressId
