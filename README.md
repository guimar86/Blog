## Feature: Blogging Platform RESTful API

### Scenario: User creates a new blog post

Given the user is authenticated with valid credentials
When the user submits a new blog post with the title "Sample Post" and content "This is a sample blog post content."
Then the system should respond with a 201 Created status
And the response should contain the created blog post details

### Scenario: User retrieves a list of blog posts

Given the user is authenticated with valid credentials
When the user requests the list of blog posts
Then the system should respond with a 200 OK status
And the response should contain a list of blog posts with their details

### Scenario: User updates an existing blog post

Given the user is authenticated with valid credentials
And there exists an existing blog post with the title "Existing Post" and content "Original content."
When the user updates the content of the blog post with the title "Existing Post" to "Updated content."
Then the system should respond with a 200 OK status
And the response should contain the updated blog post details

### Scenario: User deletes an existing blog post

Given the user is authenticated with valid credentials
And there exists an existing blog post with the title "Post to Delete" and content "Content to delete."
When the user requests to delete the blog post with the title "Post to Delete"
Then the system should respond with a 204 No Content status
And the blog post with the title "Post to Delete" should no longer exist in the system

### Scenario: User comments on a blog post

Given the user is authenticated with valid credentials
And there exists an existing blog post with the title "Post with Comments" and content "Content to comment on."
When the user submits a comment "Great post!" on the blog post with the title "Post with Comments"
Then the system should respond with a 201 Created status
And the response should contain the created comment details

### Scenario: User retrieves comments on a blog post

Given the user is authenticated with valid credentials
And there exists an existing blog post with the title "Post with Comments" and content "Content with comments."
When the user requests the comments for the blog post with the title "Post with Comments"
Then the system should respond with a 200 OK status
And the response should contain a list of comments with their details for the specified blog post
