# RealWare Integrations
This repository contains examples for integrating with the RealWare API, external services, and other third-party systems.

## Custom External Approach Service(s)
RealWare provides a way to use external cost, market, and income approaches via a web-based service.

### Setup
1. Download the repository and open the solution RealWare.ExternalServices.sln.
- **Note: This will require an IDE like Visual Studio or VSCode.**

2. Run the project in DEBUG as HTTP and make note of the port for the localhost.
![image](https://github.com/user-attachments/assets/37c96167-ca5b-46b7-8fe5-e38cc4b9c39b)

- **Note: Special configuration will be required for HTTPS.**

### RealWare Configuration - System Maintenance
3. In RealWare, open System Maintenance:

   ![image](https://github.com/user-attachments/assets/473d6e42-7c88-4bb4-afb9-99151c348ca0)

5. Select "Global Options->Services->Calculations" and enter in the following values:

- **For External Market Value:**
  - ExternalMarketCalculationServiceURL=```http://localhost:5152/api/ExternalApproach/TestExternalMarketValue```

- **For External Income Value:**
  - ExternalIncomeCalculationServiceURL=```http://localhost:5152/api/ExternalApproach/TestExternalIncomeValue```
 
- **For External Cost Value:**
  - ExternalCostCalculationServiceURL=```http://localhost:5152/api/ExternalApproach/TestExternalCostValue```
  - ExternalCostCalculationDefaultQuality=```Standard```
  - ExternalCostCalculationNADARegionCode=```Central```
      - NADA codes can be referenced here: https://www.ftc.gov/sites/default/files/pdf/att._1b_-_nada_region_list.pdf.

- Save changes.
![image](https://github.com/user-attachments/assets/8cc68d85-23ba-4010-9220-ca392430e8e6)

5. **(Cost Approach Only)** Select "Table Maintenance->Improvements->Improvement External Cost" and ensure atleast one MH External Make and MH External Model exists.
  - Example: ![image](https://github.com/user-attachments/assets/b3e1edc2-b7d9-4dfd-8a15-946d95297c44)

### Test Calculation Services
**❗ IMPORTANT: The ASP.NET Core rest service must be running for the calculations to work. See Steps 1 & 2.**

6. Test the calculation service by opening an account, selecting the "Improvements" minor, and pressing calculate market, cost, and/or income.

- **For External Market Value:**
  - Click "Calculate Market"
  ![image](https://github.com/user-attachments/assets/5b8ac816-0512-4784-bc3b-6a022d7b7f79)
  - If successful, the external market value will change to 99,999.
  ![image](https://github.com/user-attachments/assets/95cf5492-4eef-4920-b5e9-b91734f0d8dc)

- **For External Income Value:**
  - Click "Calculate Income"
  ![image](https://github.com/user-attachments/assets/ba97ccf1-bd9b-48d5-8482-9710c1c8e64f)
  - If successful, the external income value will change to 99,999.
  ![image](https://github.com/user-attachments/assets/feea58e4-d982-4a00-8746-4fd4f6893bb7)

- **For External Cost Value:**
  - Select "External Cost" (calculation service will not be called unless selected)
  ![image](https://github.com/user-attachments/assets/9bae711f-cc30-4fdf-bc51-99749c070239)
  - Select a valid "MH External Make" and "MH External Model" for each built as and improvement combination:
  ![image](https://github.com/user-attachments/assets/82d5da33-33a7-44e5-9a4e-0adff9d8ce6d)
  - Click "Calculate Cost"
  
  ![image](https://github.com/user-attachments/assets/d6806b33-ae9e-4fe2-96f3-4bfb69c29e23)
  - If successful, the external cost value(s) will change to 99,999.
  ![image](https://github.com/user-attachments/assets/51a4f82d-bd1a-4374-97bd-df4525964a3d)


### Code Debugging
7. For additional testing, add a break point on the API function for debugging:
![image](https://github.com/user-attachments/assets/efe6d5df-be10-46fa-b69e-8ddd3b4d61d3)


