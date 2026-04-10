# Tasks

## Languages

    - make all texts as resources
    - new pages need their resource files

## Catgeories page

## Avis de disponibilite page

## from exemplaire to notice link

## icon sized

## etat adherent et exemplaire
```pascal
if ( N1 = N2 ) then
...
 Query1.SQL.Text := ' delete from reservation where id_adherent = ''' + id_premier_adherent + ''' and upper(cote) = ''' + strupper(cote) + ';''' ;
 Query1.ExecSQL ;
 ```

## Testing best practices

Naming standards are important because they help to express the test purpose and application. Tests are more than just making sure your code works. They also provide documentation. Just by looking at the suite of unit tests, you should be able to infer the behavior of your code and not have to look at the code itself. Moreover, when tests fail, you can see exactly which scenarios don't meet your expectations.


"Arrange, Act, Assert" pattern 

The input for a unit test should be the simplest information needed to verify the behavior you're currently testing. The minimalist approach helps tests become more resilient to future changes in the codebase and focus on verifying the behavior over the implementation


Magic strings are string values hard-coded directly in your unit tests without any code extra comment or context. These values make your code less readable and harder to maintain. Magic strings can cause confusion to the reader of your tests. 


When you write your unit tests, avoid manual string concatenation, logical conditions, such as if, while, for, and switch, and other conditions. 