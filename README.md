# ReserveWorkbookGenerator

A .NET application for generating a modern reserve funding workbook for condominium and homeowners associations.

Unlike traditional reserve study software, this project combines the financial flexibility of **pooled reserve funding** with the transparency of a traditional **component reserve schedule**.

The result is a reserve workbook that is understandable by owners, useful for Board members, and based upon sound reserve funding principles.

Developed using the Grand Cove Condominium Association as the reference implementation.
---

# Project Goals

The primary objectives of this project are to:

- Generate a professional Excel reserve workbook.
- Support pooled reserve funding.
- Present reserve information using a familiar component schedule.
- Base funding decisions on engineering principles.
- Produce transparent and auditable calculations.
- Separate reserve funding methodology from workbook presentation.
- Provide a reserve planning tool that can evolve over time.

---

# Current Status

## Version 0.4.0

### Completed

- ✅ JSON Component Import
- ✅ Reserve Schedule Builder
- ✅ Fully Funded Balance (FFB) Calculator
- ✅ FFB Weight Allocation
- ✅ Beginning Allocation Calculator
- ✅ Annual Contribution Framework
- ✅ Basic Excel Workbook Export
- ✅ Unit Test Suite

### In Progress

- Funding Methodology Research
- Hybrid FFB Funding Model
- Annual Contribution Methodology

---

# Project Architecture

```text
JSON Reserve Study
        │
        ▼
JsonComponentImporter
        │
        ▼
ReserveEngine
        │
        ├── ReserveScheduleBuilder
        ├── FfbCalculator
        ├── AllocationCalculator
        └── AnnualContributionCalculator
        │
        ▼
ExcelWorkbookExporter
        │
        ▼
Grand Cove Reserve Workbook.xlsx
```

---

# Solution Structure

```text
ReserveWorkbookGenerator.slnx

src
│
├── ReserveWorkbookGenerator
│   ├── Calculators
│   ├── Common
│   ├── Engine
│   ├── Exporters
│   ├── Importers
│   └── Models
│
├── ReserveWorkbookGenerator.Console
│
└── ReserveWorkbookGenerator.Tests

docs
│
├── Architecture.md
├── FundingMethodology.md
├── FundingResearch.md
└── README.md
```

---

# Documentation

| Document | Description |
|-----------|-------------|
| Architecture.md | Software architecture and project organization |
| FundingMethodology.md | Official reserve funding methodology |
| FundingResearch.md | Engineering notebook and methodology research |

---

# Development Workflow

Development follows a feature-based workflow.

```
One Feature
One Branch
One Merge
```

Every feature includes:

1. Unit Tests
2. Business Logic
3. Engine Integration
4. Console Verification
5. Excel Output
6. Manual Validation
7. Merge
8. Release Tag

---

# Current Funding Model

The current implementation uses a **Hybrid FFB Funding Model**.

Characteristics:

- Single pooled reserve account.
- Analytical component allocations.
- FFB-based weighting.
- Transparent reserve schedule.
- Traditional component presentation.
- Modern pooled reserve funding.

The funding methodology continues to evolve as research is performed using actual Grand Cove reserve data.

---

# Technology

- .NET 10
- C#
- ClosedXML
- xUnit
- FluentAssertions
- System.Text.Json

---

# Roadmap

## v0.5.0

- Funding Methodology
- Professional Annual Contribution Model

## v0.6.0

- Remaining Life Engine
- Override Support

## v0.7.0

- Interest Allocation
- Ending Allocation
- Fund Ratio

## v0.8.0

- Multi-Year Projection Engine

## v0.9.0

- Dashboard
- Board Reports

## v1.0.0

Production Release

---

# Project Philosophy

The purpose of this project is **not** to reproduce commercial reserve study software.

The objective is to develop a reserve funding system that:

- follows sound engineering principles,
- preserves the flexibility of pooled reserve funding,
- produces transparent financial calculations,
- is understandable by condominium owners,
- and provides Boards with a practical reserve planning tool.

The software is the implementation.

The reserve funding methodology is the product.

Version 1.0 Milestone: Domain model finalized, production GrandCove.json completed, workbook generation verified, and all unit tests passing.

# Staebler Notes
We will never match the Staebler study because of errors in their data
    Elevators - They had Last Replaced in 2017 but it should be 2006
        they had remaining life of 12 years but it should be 1 year
    Power Pedestals - They had useful life of 60 should be 20
        so remainin life was 41 should be 1 year