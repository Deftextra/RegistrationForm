# Registration Form App

Hi Radwan,

We are excited to invite you to a second interview for the developer role at edison365  meeting details in the invite from Indeed. The second interview will be 1 to 1.5 hours long and loosely following the agenda below:

	Introductions
	Company Introduction
	Edison365 product overview
	Candidate to present, demo and walkthrough activity  the details on the activity are below the agenda
o	Presentation for solution overview  PowerPoint slide deck highlighting parts of the solution and design / implementation decisions 
o	Walkthrough the solution using the chosen IDE
o	Demo solution working
	General interview questions
	General software development questions

There is a coding activity that we would like you to complete before the interview so that this can be presented back to us on the day. We would also like a copy of the source code made available to us by 09:00 Friday 26th March. The activity can be seen below:

Requirements    
	Capture and store registration details for a user. 
	Display a list of registrations.
	Optional: Ability to edit and delete existing registrations.

Registration form
Simple form built using any modern JavaScript framework. The form must be capable of sending registration data to your API. The form fields should be validated where appropriate.
Use the form to capture the following details:     
	First name
	Last name
	Mobile number
	Address
	Email
* note - Aurelia is the preferred framework; however, this is optional.

Registrations list
Display all registrations in a suitable format. The list should have the ability to edit and delete a registration.

API
A .net API capable of managing your form and list actions and interacting with your DB

Database backend
Storage of registration details. Any DB can be used (Relational or schemaless)

This can be built to run locally on your device. 

We are looking for to meeting with you on Friday via Microsoft Teams.

Please confirm that you have received the interview agenda.

## Back-end

## Models

----
### Registration
* First name
* Last nme
* Mobile number
* Address
  1. Check if address is valid

* Email
  1. Check email is valid
  2. Check if email exists (add maybe later)
---

* We separate the domain models from our boundary models. 
  This keeps our endpoints consistent for consumption even if the domain logic changes.
* We use the Repository pattern.
   * A repository holds the appDbContext, that is, it only keeps track of in memory changes to our entities.

* We name the project RegistrationRequest, because we do not want to confuse with actually creating a userIdentity with credentials. 
* We structure our project following jason taylow apploach, but without the application layer, which is merged inside with the infrastructure.

* We apply the request and Response pattern.
  This pattern gives us some advantages, such as:
	*If we need to change our service to receive more parameters, we don’t have to break its signature;
	*We can define a standard contract for our request and/or responses;
	*We can handle business logic and potential fails without stopping the application process, and we won’t need to use tons of try-catch blocks.


## Front-end
