# BudgetApp2 — title

BudgetApp2 is a platform that helps users manage expenses, set savings goals, and receive AI-powered recommendations for smarter financial decisions.

## Tech Stack — bullet list of tech stack
- Go (AI/ML recommender microservice)
- Express.js (Node.js) API Gateway
- ASP.NET Core (Core API for expenses and savings goals)

## Requirements — list of the given requirements
- Manage and track expenses
- Create and manage savings goals
- Provide AI-powered recommendations for smarter financial decisions
- Use Go, Express.js, and ASP.NET Core across AI/ML, API, and Back-End domains

## Installation — stack-specific setup commands and environment variable instructions

Prerequisites
- Node.js 18+ and npm
- Go 1.21+
- .NET SDK 7+ (or newer)

Repository structure (proposed)

BudgetApp2/
  services/
    api-gateway/           # Express.js API Gateway
      package.json
      src/
        server.js
      .env.example
    core-api/              # ASP.NET Core Minimal API for expenses/goals
      Program.cs
      BudgetApp2.CoreApi.csproj
      appsettings.json
      appsettings.Development.json.example
    recommender/           # Go service for AI recommendations
      main.go
      go.mod


Common Ports (can be changed via env)
- API Gateway (Express.js): 3000
- Core API (ASP.NET Core): 5100
- Recommender (Go): 5200

1) API Gateway (Express.js)
- Navigate and install

cd services/api-gateway
npm install

- Environment variables (copy example and adjust if needed)

cp .env.example .env

- .env variables

PORT=3000
CORE_API_BASE_URL=http://localhost:5100
RECOMMENDER_BASE_URL=http://localhost:5200
NODE_ENV=development

- Start

npm run dev   # if using a dev script
# or
npm start


2) Core API (ASP.NET Core)
- Navigate and restore/build

cd services/core-api
 dotnet restore
 dotnet build

- Configuration
  - appsettings.json is included for defaults
  - For development, copy the example and edit as needed:

cp appsettings.Development.json.example appsettings.Development.json

- Useful environment variables

ASPNETCORE_URLS=http://localhost:5100
DOTNET_ENVIRONMENT=Development

- Run

dotnet run


3) Recommender (Go)
- Navigate and prepare

cd services/recommender
go mod tidy

- Optional environment variables

export PORT=5200
export LOG_LEVEL=info

- Run

go run ./main.go


## Usage — based on the generated implementation steps
1) Start all three services:
- Core API (ASP.NET Core) on http://localhost:5100
- Recommender (Go) on http://localhost:5200
- API Gateway (Express.js) on http://localhost:3000

2) Use the API Gateway for client requests.

Examples (via API Gateway):
- Add an expense

curl -X POST http://localhost:3000/api/expenses \
  -H "Content-Type: application/json" \
  -d '{
    "date": "2025-01-10",
    "category": "Food",
    "amount": 23.45,
    "note": "Lunch"
  }'

- Create a savings goal

curl -X POST http://localhost:3000/api/goals \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Emergency Fund",
    "targetAmount": 2000,
    "deadline": "2025-12-31"
  }'

- Get AI recommendations by sending a snapshot of expenses and goals

curl -X POST http://localhost:3000/api/recommendations \
  -H "Content-Type: application/json" \
  -d '{
    "monthlyIncome": 5000,
    "expenses": [
      {"date":"2025-01-10","category":"Food","amount":23.45},
      {"date":"2025-01-11","category":"Transport","amount":12.00}
    ],
    "goals": [
      {"name":"Emergency Fund","targetAmount":2000,"deadline":"2025-12-31"}
    ]
  }'


## Implementation Steps — numbered list of generated steps
1. Create the repository layout with three services:
   - services/api-gateway (Express.js)
   - services/core-api (ASP.NET Core)
   - services/recommender (Go)
2. Define domain models shared conceptually across services:
   - Expense: id (string/Guid), date (ISO string), category (string), amount (number), note (string, optional)
   - Goal: id (string/Guid), name (string), targetAmount (number), deadline (ISO string), currentAmount (number, optional)
   - Recommendation: id, title, description, priority (e.g., low/medium/high), relatedCategories (string[])
3. Implement Core API (ASP.NET Core) using Minimal APIs:
   - CRUD endpoints for /v1/expenses and /v1/goals
   - In-memory storage for initial implementation
   - Basic validation and error responses
   - Health endpoint /health
4. Implement Recommender service (Go):
   - POST /recommendations accepts a snapshot: { monthlyIncome, expenses[], goals[] }
   - Compute suggestions using simple heuristics (e.g., spending-to-income ratios, category caps, progress toward goals)
   - Return actionable recommendations with priorities
   - Health endpoint /healthz
5. Implement API Gateway (Express.js):
   - Proxy routes:
     - /api/expenses -> Core API /v1/expenses
     - /api/goals -> Core API /v1/goals
     - /api/recommendations -> Recommender /recommendations
   - Centralized error handling and request validation
   - Configure base URLs via environment variables
6. Wire inter-service communication over HTTP using the base URLs from environment variables.
7. Add configuration files that are standard for each stack:
   - api-gateway: package.json, .env.example, src/server.js
   - core-api: Program.cs, appsettings.json, appsettings.Development.json.example, BudgetApp2.CoreApi.csproj
   - recommender: go.mod, main.go
8. Add basic logging in each service (stdout) with configurable log levels via environment variables where applicable.
9. Verify local run with health checks and sample curl requests through the API Gateway.
10. Extend the recommender logic iteratively and refine validation, pagination, and filtering as needed.

## API Endpoints — only if API endpoints are implied by stack or requirements

API Gateway (Express.js)
- GET /api/health → returns { status: "ok" }
- Expenses
  - GET /api/expenses
  - POST /api/expenses
  - GET /api/expenses/:id
  - PUT /api/expenses/:id
  - DELETE /api/expenses/:id
- Goals
  - GET /api/goals
  - POST /api/goals
  - GET /api/goals/:id
  - PUT /api/goals/:id
  - DELETE /api/goals/:id
- Recommendations
  - POST /api/recommendations
    - Request: { monthlyIncome: number, expenses: Expense[], goals: Goal[] }
    - Response: { recommendations: Recommendation[] }

Core API (ASP.NET Core)
- GET /health → { status: "ok" }
- Expenses
  - GET /v1/expenses
  - POST /v1/expenses
  - GET /v1/expenses/{id}
  - PUT /v1/expenses/{id}
  - DELETE /v1/expenses/{id}
- Goals
  - GET /v1/goals
  - POST /v1/goals
  - GET /v1/goals/{id}
  - PUT /v1/goals/{id}
  - DELETE /v1/goals/{id}

Recommender (Go)
- GET /healthz → { status: "ok" }
- POST /recommendations
  - Request

{
  "monthlyIncome": 5000,
  "expenses": [ {"date":"2025-01-10","category":"Food","amount":23.45} ],
  "goals": [ {"name":"Emergency Fund","targetAmount":2000,"deadline":"2025-12-31"} ]
}

  - Response

{
  "recommendations": [
    {
      "id": "rec-1",
      "title": "Reduce discretionary spending",
      "description": "Food spending exceeds 15% of income. Consider a weekly cap.",
      "priority": "medium",
      "relatedCategories": ["Food"]
    }
  ]
}