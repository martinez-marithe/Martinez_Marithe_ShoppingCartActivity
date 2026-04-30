# Martinez_Marithe_EnhancedShoppingCartActivity_Part2

---

## Project Description 
This project is an enhanced version of my original console-based Shopping Cart System developed using C#. 
It simulates a skincare store where users can search products, filter by category, add products to cart, 
manage cart items before checkout, validate payment, generate receipts with receipt number and date/time, monitor low-stock products, 
and store order history during the program run. This version focuses on improving user interaction, validation, stock management, 
and overall shopping experience while still using C# concepts such as classes, objects, arrays, methods, loops, and conditionals.

---

## Store Name
GLOW & CARE SKINCARE STORE V2.0

---

## Part 1 Revision (Comments Addressed)
### Comments Fixed:
- `Program.cs` is now the proper entry point containing the full `Main()` method  
- `Product.cs` now properly contains only:
  - Product class
  - CartItem class
  - Order class
- Continue prompts (`Y/N`) now use strict validation and re-prompt until valid input is entered  
- Improved overall code organization 
- Revised part 1 AI usage in README.md

---

## Part 2 - New Features Added

- Search products by product name or category
- Category filter system:
  - Skincare
  - Treatment
  - Cleanser
- Full cart management menu:
  - View cart
  - Checkout
  - Remove item
  - Update item quantity
  - Clear cart
  - Back to main menu
- Better Y/N validation
- Payment validation:
  - Numeric input only
  - Re-prompts for insufficient payment
- Receipt improvements:
  - Receipt number
  - Date and time
  - Purchased items
  - Grand total
  - Discount
  - Final total
  - Payment
  - Change
- Low stock alert after checkout (`RemainingStock <= 5`)
- Order history tracking during runtime using arrays
- Improved menu structure and navigation

## Part 1 - Original Features Still Included
- Product display using an array of objects
- Input validation using int.TryParse()
- Stock management system
- Prevents purchasing beyond available stock
- Prevents duplicate cart entries by updating existing item quantity instead of adding a new row
- Automatic 10% discount when total reaches P5000 or more
- Receipt with itemized list, grand total, discount, and final total

---

## Concepts Applied
- Classes and Objects
- Arrays of Objects
- Methods
- Conditional Statements (if, else if, else)
- Loops (while, for)
- Input Validation using int.TryParse and double.TryParse
- Basic Arithmetic Operations
- DateTime for receipt timestamp
- Two-file project structure (Program.cs and Product.cs)

--- 

## Project Structure
- Program.cs - Contains the Main() method and all program logic
- Product.cs - Contains the Product, CartItem, and Order class definitions
- README.md - Project documentation

---

## How to Run
1. Open the project in Microsoft Visual Studio 2022 or 2026
2. Make sure both Program.cs and Product.cs are inside the same project
3. Build the solution
4. Run the program
5. Follow the on-screen prompts to search products, manage cart, checkout, and view history
	
---

## Sample Program Output (Part 2)
=== GLOW & CARE SKINCARE STORE V2.0 ===
1. Search & Add
2. Filter by Category
3. Manage Cart
4. Order History
5. Exit
Select No.: 1
Enter product name to search: cleanser
4. [Cleanser] Cleansing Oil - P800 (Stock: 12)
5. [Cleanser] Gentle Facial Cleanser - P560 (Stock: 15)
Enter ID: 5
Quantity: 2
Added to cart!
Add another item? (Y/N): N

--- CART ---
1. Gentle Facial Cleanser x2 = P1120

1. Checkout
2. Remove Item
3. Update item quantity
4. Clear Cart
5. Back
Choice No.: 1
Final Total: P1120
Payment: 1500

=== RECEIPT ===
Receipt No: 0001
Date: April 30, 2026 11:45 pm
Items:
Gentle Facial Cleanser x2 = P1120
Grand Total: P1120
Discount: P0
Final Total: P1120
Payment: P1500
Change: P380

LOW STOCK ALERT:
AHA/BHA Exfoliant Set has only 3 stocks left.

ORDER HISTORY
Receipt #0001 - Final Total: P1120 - April 30, 2026 11:45 pm

## Screenshots
- [Click here to view the Program Output Screenshots (PDF)](./Part%202%20screenshot%20sample%20output.pdf)

---

## AI Usage in This Project
AI tools were used in this project for guidance, debugging, and explanation purposes only. All code was written, tested, and adjusted by the student.
 
### 1. Specific uses of AI in Part 2:
- Understanding how to improve menu navigation
- Learning how to structure Search & Add logic
- Guidance on category filtering
- Help understanding cart management features
- Debugging:
  - Loop problems
  - Y/N validation
  - Menu validation
  - Logic flow issues
  - Cart update and remove logic
- Understanding receipt formatting
- README formatting guidance

### 2. Why AI was used:
- To understand new concepts needed for Part 2 that I had not fully learned yet
- To find and fix logic errors that were difficult to spot on my own
- To learn how DateTime formatting and number formatting work in C#
- To confirm that my stock management logic was correct in the remove and update features

### 3. Prompts/Questions asked:
- How to add search by product name in C#?
- How to filter products by category?
- How to validate Y/N prompts correctly?
- How to store order history using arrays?
- How to generate receipt number and date?
- How to debug cart quantity updates?

### 4. What I did after using AI for guidance:
- Rewrote and adjusted the code based on what I understood from the explanation
- Added the oldQty variable myself after learning why it was necessary
- Wrote the low stock alert loop myself and only used AI to confirm the condition
- Fixed the search loop break condition myself after AI explained the issue
- Tested all features manually by running the program multiple times
- Corrected remaining issues on my own through trial and error

### 5. Academic integrity statement:
AI was used only as a guide, learning and debugging support tool for this Activity.
All code submitted was typed by the student, reviewed manually, and understood before submission.
The student is able to explain:
- How the cart management menu works
- How stock is returned when items are removed or quantity is updated
- How the payment validation loop keeps asking until a valid amount is entered
- How the receipt prints all required fields
- How order history is saved and displayed during the session
  
AI was used ethically and responsibly as a study support tool.


Martinez, Marithe C.
BSIT 1-2
Computer Programming 2
Polytechnic University of the Philippines - San Pedro Campus
