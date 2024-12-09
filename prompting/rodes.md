# RODES - Role, Objective, Details, Example, Sense Check
## Role 
The role defines who you are in the context of the task. It sets the perspective and scope of your actions. For example, you might be a software developer, a project manager, or a data analyst. Understanding your role helps in aligning your actions with the expectations and responsibilities associated with it.

## Objective
The objective specifies what you aim to achieve. It provides a clear goal for your task. For instance, your objective might be to develop a new feature, complete a project on time, or analyze a dataset to extract meaningful insights. A well-defined objective helps in maintaining focus and measuring success.

## Details
The details section includes all the necessary information and constraints related to the task. It helps in understanding the context and requirements. This might include technical specifications, deadlines, resource availability, and any other relevant information. Having detailed information ensures that you are well-prepared and can plan effectively.

## Example
An example illustrates how the task can be approached or completed. It serves as a reference or guide. For instance, if your task is to write a function, an example might show a similar function with comments explaining each step. Examples help in clarifying expectations and providing a concrete starting point.

**Example for RTF RODES:**

**Role:** Software Developer

**Objective:** Develop a new feature for the company's main application.

**Details:** 
- Feature: User authentication
- Deadline: 2 weeks
- Resources: Access to the current codebase, design documents, and a test environment

**Example:**
```python
def authenticate_user(username, password):
    # Check if the username exists in the database
    user = database.get_user(username)
    if user and user.check_password(password):
        return True
    return False
```

**Sense Check:**
The sense check ensures that the task and its components make sense and are feasible. It involves reviewing and validating the information provided. This might include checking for logical consistency, verifying that the objectives are achievable within the given constraints, and ensuring that all necessary details are included. A sense check helps in identifying potential issues early and making necessary adjustments.

## Example Prompts

### Prompt 1
**Role:** Data Analyst

**Objective:** Analyze sales data to identify trends and insights.

**Details:** 
- Data: Sales data from the past year
- Deadline: 1 week
- Resources: Access to the sales database, data visualization tools

**Example:**
```python
import pandas as pd
import matplotlib.pyplot as plt

# Load the sales data
data = pd.read_csv('sales_data.csv')

# Analyze the data
monthly_sales = data.groupby('month').sum()

# Plot the sales trends
plt.plot(monthly_sales.index, monthly_sales['sales'])
plt.xlabel('Month')
plt.ylabel('Sales')
plt.title('Monthly Sales Trends')
plt.show()
```

### Prompt 2
**Role:** Project Manager

**Objective:** Ensure the project is completed on time and within budget.

**Details:** 
- Project: Website redesign
- Deadline: 3 months
- Resources: Team of 5 developers, budget of $50,000

**Example:**
```markdown
1. Define project scope and objectives
2. Create a detailed project plan with milestones
3. Assign tasks to team members
4. Monitor progress and adjust plan as needed
5. Ensure project stays within budget
6. Conduct regular team meetings to address issues
7. Deliver the final product on time
```

### Prompt 3
**Role:** Software Tester

**Objective:** Test the new user authentication feature for bugs and security issues.

**Details:** 
- Feature: User authentication
- Deadline: 1 week
- Resources: Access to the test environment, test cases, and bug tracking tool

**Example:**
```python
def test_authentication():
    # Test case 1: Valid username and password
    assert authenticate_user('valid_user', 'valid_password') == True
    
    # Test case 2: Invalid username
    assert authenticate_user('invalid_user', 'valid_password') == False
    
    # Test case 3: Invalid password
    assert authenticate_user('valid_user', 'invalid_password') == False
    
    # Test case 4: SQL injection attempt
    assert authenticate_user('valid_user', "' OR '1'='1") == False

test_authentication()
```

