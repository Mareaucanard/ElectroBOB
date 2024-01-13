# Electro-Bob Documentation
## Table of contents
- Project architecture
- Interactions
- Usage

## Project Architecture

### Controllers ans Models

![controllers](./doc_images/controllers.png)

Electro-Bob uses multiple controllers to handle requests.

![models](./doc_images/models.png)

- Preferences are the preferences of the user for various settings.
- Area is a class that contains an action. It can have up to 5 corresponding reactions.
- Users contains all the information relative to an user, such as password, username, preferences, etc.
- ActionTrigger and ReactionTrigger are the conditions of activation for Actions and reactions respectively.
- ActionCatalog and ReactionCatalog are templates for "standard" actions. This is to separate them from "custom" actions which will be implemented later.

## Interactions

When the program scans over all the Action and Reaction triggers, it will execute the ones that are triggered at the time.

They will interact with Area, which will handle the action. And the Area itself will use the corresponding User's data to send information accordingly.

## Usage

