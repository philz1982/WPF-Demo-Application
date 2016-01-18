# WPF-Demo-Application
##Overview
The purpose of this application is to demonstrate how a WPF application can be used to take human input and perform a series of functions
to calculate prices as well as to replace text in a template document with the human input.
##How it Works
The application is fairly simple. It consists of one WPF window that has 3 tab-items. Under each tab-item there are XAML tags that either
collect data or perform functions. Currently there are 3 functions in the the application 2 of the functions CalculatePrice and CreateProposal
are driven of ClickEvents the third function CalcPrice is executed as part of the two functions
###CalculatePrice Function
This function is driven by the CalculatePrice button and it simply executes the CalcPrice Function.
###CalcPrice Function
This function takes input from the Financial Data tab-item and Calculates a price. It returns text values to the Create Proposal Tab-item
and it is used to create the proposal.
###CreateProposal Function
Create proposal utilizes the DocX library and takes the input from the Financial Data and Customer Data Tab-Items. It then replaces strings
within the template document. The template and final document locations are hard coded within this funciton. The template document must
be in the hardcoded folder and the final document folder must exist for this application to work. The files and folders can be coded to be
relative rather than absolute locations. 

The CreateProposal function also calls the CalcPrice function to calculate price.
##FAQ
Added as they come
