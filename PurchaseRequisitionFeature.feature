Feature: PurchaseRequisitionFeature
	In order to check if there is no problem, while creating a Purchase Requisition
	As a tester
	I want to check from the beginning to the end, if there is no problem while creating a Purchase Requisition

@mytag
Scenario: The Purchase Requisition should be submitted successfully
	Given I have saved the details of the Purchase Requisition webpage
	And I have submitted those details
	When I accept the popup message
	Then there should be a message that says that the Purchase Requisition has been submitted
