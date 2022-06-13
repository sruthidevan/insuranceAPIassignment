**# Insurance-API**

**User Story:**

We want to be able to insure the products that we sell to a customer, so that we get money back in case the product gets lost or damaged before reaching the customers. For that, we need a REST API that is going to be used by the webshop. You're going to get access to our Product Information API:

1.	Unzip it onto your machine
2.	Navigate to the unzipped folder in a terminal
3.	On the terminal, type dotnet ProductData.Api.dll and hit Enter.

Your screen should look like as shown below if the API has successfully started:

 ![image](https://user-images.githubusercontent.com/20437478/173346523-c86e0f33-158e-48a8-b7e7-368397bc791c.png)


The Products API is Swagger enabled, and you can access it by navigating to http://localhost:5002/ in your browser. In the example the port is 5002.

Functionality already implemented here:
There is an existing endpoint that, given the information about the product, calculates the total cost of insurance according to the rules below:
  - If the product sales price is less than € 500, no insurance required
  - If the product sales price=> € 500 but < € 2000, insurance cost is € 1000
  - If the product sales price=> € 2000, insurance cost is €2000
  - If the type of the product is a smartphone or a laptop, add € 500 more to the insurance cost.

_* Download the current code, so you can continue with the further tasks._

**Task 1 [BUGFIX]:**
The financial manager reported that when customers buy a laptop that costs less than € 500, insurance is not calculated, while it should be € 500.

**Task 2 [REFACTORING]:**
It looks like the already implemented functionality has some quality issues. Refactor that code, but be sure to maintain the same behavior. 

_* Please make sure to include in the documentation about the approach that you chose for the refactoring._

**Task 3 [FEATURE 1]:**
Now we want to calculate the insurance cost for an order and for this, we are going to provide all the products that are in a shopping cart.

_* While developing this feature, please document your assumptions and feel free to reach the stakeholders for doubts via Slack._

**Task 4 [FEATURE 2]:**
We want to change the logic around the insurance calculation. We received a report from our business analysts that digital cameras are getting lost more than usual. Therefore, if an order has one or more digital cameras, add € 500 to the insured value of the order.

_* While developing this feature, please document your assumptions and feel free to reach the stakeholders for doubts via Slack._

**Task 5 [FEATURE 3]:**
As a part of this story we need to provide the administrators/back office staff with a new endpoint that will allow them to upload surcharge rates per product type. This surcharge will then  need to be added to the overall insurance value for the product type.
Please be aware that this endpoint is going to be used simultaneously by multiple users.

_* While developing this feature, please document your assumptions and feel free to reach out to the stakeholders for doubts via Slack._
