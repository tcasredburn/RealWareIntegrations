# RealWare Integrations
This repository contains examples for integrating with the RealWare API, external services, and other third-party systems.

## Custom External Approach Service(s)
RealWare provides a way to use external cost, market, and income approaches via a web-based service.

### Setup
1. Download the repository and open the solution RealWare.ExternalServices.sln.
- **Note: This will require an IDE like Visual Studio or VSCode.**

2. Run the project in DEBUG as HTTP and make note of the port for the localhost.
![image](https://github.com/user-attachments/assets/f4a0526c-61e5-43b5-a949-8402f94d12b3)

- **Note: Special configuration will be required for HTTPS.**

3. In RealWare, open System Maintenance:

![image](https://github.com/user-attachments/assets/473d6e42-7c88-4bb4-afb9-99151c348ca0)

4. Select "Calculations" and enter in the following values:

- For External Market Value:
  - ```http://localhost:5152/api/ExternalApproach/TestExternalMarketValue```

- For External Cost Value:
  - ```http://localhost:5152/api/ExternalApproach/TestExternalIncomeValue```

- Save changes.
![image](https://github.com/user-attachments/assets/5bad1835-a14f-4489-8eba-b8a9ee55c2e6)

5. Test the calculation service by opening an account, selecting the "Improvements" minor, and pressing calculate market and/or income.
![image](https://github.com/user-attachments/assets/5b8ac816-0512-4784-bc3b-6a022d7b7f79)

- If successful, the external market value for market will change to 99,999.
![image](https://github.com/user-attachments/assets/95cf5492-4eef-4920-b5e9-b91734f0d8dc)


- For additional testing, add a break point on the API function for debugging:
![image](https://github.com/user-attachments/assets/efe6d5df-be10-46fa-b69e-8ddd3b4d61d3)


