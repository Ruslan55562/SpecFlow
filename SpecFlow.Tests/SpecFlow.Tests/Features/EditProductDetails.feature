Feature: Editing Product Details And Adding It To Cart
  As a user of the site
  I want to edit product details and add them to cart

@mytag
Scenario: Opportunity to edit product details
	Given User is at the Home Page
	And Enter the 'Blouse' keyword and click on Search icon
	And Click on the More button of the first product
	And Set the Quantity = '3', Size = 'L', Color = 'white' details
	And Click on Add to Cart button
	When The "Product successfully added to your shopping cart" modal window appears
	And Click on Continue Shopping button
	And Enter the 'Printed summer dress' keyword and click on Search icon
	And Click on the More button of the first product
	And Set the Quantity = '5', Size = 'M', Color = 'Orange' details
	And Click on Add to Cart button
	When The "Product successfully added to your shopping cart" modal window appears
	And Click on "Proceed to checkout" button
	And Verify the actual details with the expected 
	And Click on Delete button opposite 'Printed summer dress'
	Then Only 'Blouse' product displays