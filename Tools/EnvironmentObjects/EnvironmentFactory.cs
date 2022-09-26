/*Factory object to generate all environment objects*/

/*TODO: Implement case logic for all environment blocks*/

class environmentFactory
{
    IEnvironment GetEnvironment(int environment)
    {

        return new Statue();
    }
}
