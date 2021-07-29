# TVCommercialOptimiser
A console application evaluates the given commercials and the ratings and find the optimised ratings and its combinations. This application implementated using C#, .Net 5 and .Net Standard.

# Structure
- Program.cs to kick start the application.
- CommercialOptimiserService is used to get the instance of ICommercialOptimiser.
- Internally, the CommercialOptimiserService creates and returns an instance of CommercialOptimiser internal class which is a type of ICommercialOptimiser.
- Models - Break, Commercials, and the enums are used to implement the application's logic.

# Requirements
- Visual Studio
- .Net 5
- C#

# External Packages Used
- Combinatorics
```Install-Package Combinatorics -Version 2.0.0```
- Newtonsoft.Json
```Install-Package Newtonsoft.Json -Version 13.0.1```

# Implementation 
- Ratings and Commercials json files are added to the console application.
- Commercials and ratings are serialised from the files and used for optimisation.
- There inputs are received as the ads limit for each breaks.
- Different combinations are generated based on the inputs.
- Given filters are applied to the combinations.
- Arrived to the optimised ratings by calculating the ratings based on the Demographics.
- Maximum optimised rating and its combination are displayed in the console application.

# Output
----- Welcome to TV Commercial Optimiser -----

For the given commercials and ratings, the maximum ratings can be obtained by the following commercial comminations.

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 4, Automotive, M_18_35 Commercial 7, Finance, M_18_35 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 
Break 3 - 
Commercial 6, Finance, W_25_30 Commercial 8, Automotive, T_18_40 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 4, Automotive, M_18_35 Commercial 7, Finance, M_18_35 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 
Break 3 - 
Commercial 8, Automotive, T_18_40 Commercial 9, Travel, W_25_30 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 4, Automotive, M_18_35 Commercial 7, Finance, M_18_35 
Break 2 - 
Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 Commercial 9, Travel, W_25_30 
Break 3 - 
Commercial 6, Finance, W_25_30 Commercial 8, Automotive, T_18_40 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 4, Automotive, M_18_35 Commercial 10, Finance, T_18_40 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 
Break 3 - 
Commercial 6, Finance, W_25_30 Commercial 8, Automotive, T_18_40 Commercial 9, Travel, W_25_30 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 4, Automotive, M_18_35 Commercial 10, Finance, T_18_40 
Break 2 - 
Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 Commercial 9, Travel, W_25_30 
Break 3 - 
Commercial 1, Automotive, W_25_30 Commercial 6, Finance, W_25_30 Commercial 8, Automotive, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 5, Automotive, M_18_35 Commercial 7, Finance, M_18_35 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 
Break 3 - 
Commercial 6, Finance, W_25_30 Commercial 8, Automotive, T_18_40 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 5, Automotive, M_18_35 Commercial 7, Finance, M_18_35 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 
Break 3 - 
Commercial 8, Automotive, T_18_40 Commercial 9, Travel, W_25_30 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 5, Automotive, M_18_35 Commercial 7, Finance, M_18_35 
Break 2 - 
Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 Commercial 9, Travel, W_25_30 
Break 3 - 
Commercial 6, Finance, W_25_30 Commercial 8, Automotive, T_18_40 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 5, Automotive, M_18_35 Commercial 10, Finance, T_18_40 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 
Break 3 - 
Commercial 6, Finance, W_25_30 Commercial 8, Automotive, T_18_40 Commercial 9, Travel, W_25_30 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 5, Automotive, M_18_35 Commercial 10, Finance, T_18_40 
Break 2 - 
Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 Commercial 9, Travel, W_25_30 
Break 3 - 
Commercial 1, Automotive, W_25_30 Commercial 6, Finance, W_25_30 Commercial 8, Automotive, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 7, Finance, M_18_35 Commercial 8, Automotive, T_18_40 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 
Break 3 - 
Commercial 6, Finance, W_25_30 Commercial 9, Travel, W_25_30 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 3, Travel, T_18_40 Commercial 7, Finance, M_18_35 Commercial 8, Automotive, T_18_40 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 
Break 3 - 
Commercial 6, Finance, W_25_30 Commercial 9, Travel, W_25_30 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 4, Automotive, M_18_35 Commercial 7, Finance, M_18_35 Commercial 8, Automotive, T_18_40 
Break 2 - 
Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 Commercial 9, Travel, W_25_30 
Break 3 - 
Commercial 1, Automotive, W_25_30 Commercial 3, Travel, T_18_40 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 5, Automotive, M_18_35 Commercial 7, Finance, M_18_35 Commercial 8, Automotive, T_18_40 
Break 2 - 
Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 Commercial 9, Travel, W_25_30 
Break 3 - 
Commercial 1, Automotive, W_25_30 Commercial 3, Travel, T_18_40 Commercial 10, Finance, T_18_40 

Break 1 - 
Commercial 7, Finance, M_18_35 Commercial 8, Automotive, T_18_40 Commercial 10, Finance, T_18_40 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 
Break 3 - 
Commercial 3, Travel, T_18_40 Commercial 6, Finance, W_25_30 Commercial 9, Travel, W_25_30 

Break 1 - 
Commercial 7, Finance, M_18_35 Commercial 8, Automotive, T_18_40 Commercial 10, Finance, T_18_40 
Break 2 - 
Commercial 1, Automotive, W_25_30 Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 
Break 3 - 
Commercial 3, Travel, T_18_40 Commercial 6, Finance, W_25_30 Commercial 9, Travel, W_25_30 

Break 1 - 
Commercial 7, Finance, M_18_35 Commercial 8, Automotive, T_18_40 Commercial 10, Finance, T_18_40 
Break 2 - 
Commercial 2, Travel, M_18_35 Commercial 4, Automotive, M_18_35 Commercial 9, Travel, W_25_30 
Break 3 - 
Commercial 1, Automotive, W_25_30 Commercial 3, Travel, T_18_40 Commercial 6, Finance, W_25_30 

Break 1 - 
Commercial 7, Finance, M_18_35 Commercial 8, Automotive, T_18_40 Commercial 10, Finance, T_18_40 
Break 2 - 
Commercial 2, Travel, M_18_35 Commercial 5, Automotive, M_18_35 Commercial 9, Travel, W_25_30 
Break 3 - 
Commercial 1, Automotive, W_25_30 Commercial 3, Travel, T_18_40 Commercial 6, Finance, W_25_30 

The maximum rating obtained is 2090

Press any key to exit.

