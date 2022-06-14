**# Insurance-API**

**Task 1 [BUGFIX]:**
The financial manager reported that when customers buy a laptop that costs less than € 500, insurance is not calculated, while it should be € 500.

Decisions:
_- updated the logic implemented in IF statement._

**Task 2 [REFACTORING]:**
It looks like the already implemented functionality has some quality issues. Refactor that code, but be sure to maintain the same behavior. 

Decisions:
_- moved and renamed Dto to Models folder._
_- restructured and compartmentalized code into single responsibility classes._
_- tried to maintain a more RESTful approach (request-response dtos_
_- moved insurance calculator method out of Controller and into Business Rules class._

**Task 3 [FEATURE 1]:**
Now we want to calculate the insurance cost for an order and for this, we are going to provide all the products that are in a shopping cart.

Decisions:
_- implemented Repositry pattern to handle shopping carts with multiple products and adjustable quantities per product._

_- created separate controllers for products, carts and insurance calculation._

**Task 4 [FEATURE 2]:**
We want to change the logic around the insurance calculation. We received a report from our business analysts that digital cameras are getting lost more than usual. Therefore, if an order has one or more digital cameras, add € 500 to the insured value of the order.

Decisions:
_- checks if an order (CartResponseDto) has one or more digital cameras and adds an additional insurance to the total value of the insurance for that order._

**Task 5 [FEATURE 3]:**
As a part of this story we need to provide the administrators/back office staff with a new endpoint that will allow them to upload surcharge rates per product type. This surcharge will then  need to be added to the overall insurance value for the product type.
Please be aware that this endpoint is going to be used simultaneously by multiple users.

_- This task was skipped._

**Additional comments/Missing functionalities:**
_- Unit testing for this project is not extensive._
_- Unsure on whether documentation is enough._
