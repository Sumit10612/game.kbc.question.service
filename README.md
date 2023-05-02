```plantuml
@startuml
!define Table(name,desc) class name as "desc" << (T,#FFAAAA) >>
!define primary_key(x) <u>x</u>
!define foreign_key(x) x
hide circle
skinparam classAttributeIconSize 0

Table(Customer, "Customer") {
  + primary_key(id)
  --
  name
  address
  email
}

Table(Order, "Order") {
  + primary_key(id)
  --
  date
  amount
  + foreign_key(customer_id)
}

Table(OrderItem, "OrderItem") {
  + primary_key(id)
  --
  quantity
  + foreign_key(order_id)
  + foreign_key(product_id)
}

Table(Product, "Product") {
  + primary_key(id)
  --
  name
  price
}

Customer --{ Order
Order --{ OrderItem
OrderItem }-- Product
@enduml

