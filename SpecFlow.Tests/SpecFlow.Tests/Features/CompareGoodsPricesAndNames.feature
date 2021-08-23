Feature: CompareGoodsPricesAndNames
	As a user of the site
	I want to compare the price of the item on the shopping page 
	with the price of the item in the cart

@SHOPPING-CART
Scenario: Equal prices and product names in Shopping-cart
	Given User is at the Home Page
	When  Enter the Summer keyword and Click on Search icon
	When  The SUMMER inscription displays above the list of products
	And   Choose the dropdown option Price: Highest first
	And   Elements sorts with the choosen option
	When  Save full name and price  of the first product
	And   Add it to cart
	Then  Compare the saved values with the Price and Name in the Total column