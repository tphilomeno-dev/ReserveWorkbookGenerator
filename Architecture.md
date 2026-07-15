# Reserve Workbook Generator

## Purpose

Provide condominium associations with a reserve management system that combines pooled reserve funding with a traditional component reserve schedule.

## Design Goals

- Clean architecture
- Test-driven development
- No business logic in Excel
- Workbook generated entirely from C#
- Generic enough for any condominium association

## Core Concepts

- ReserveComponent
- ReserveScheduleRow
- ReserveEngine
- Calculators
- Excel Exporter

# Architecture

## Overview

ReserveWorkbookGenerator is designed around a simple principle:

> **Each class has one responsibility.**

Business calculations are separated from workflow orchestration, making the application easier to understand, test, and extend.

---

# High-Level Architecture

```text
                    JSON Reserve Study
                           │
                           ▼
                 JsonComponentImporter
                           │
                           ▼
                  Reserve Components
                           │
          ┌────────────────┴────────────────┐
          │                                 │
          ▼                                 ▼
    ReserveEngine                   ProjectionEngine
          │                                 │
          ▼                                 ▼
  Reserve Schedule                 Financial Projection
          │                                 │
          └────────────────┬────────────────┘
                           │
                           ▼
                 ExcelWorkbookExporter
                           │
                           ▼
            Grand Cove Reserve Workbook
```

---

# Project Structure

```text
ReserveWorkbookGenerator.slnx

src
│
├── ReserveWorkbookGenerator
│   ├── Calculators
│   ├── Common
│   ├── Engine
│   ├── Exporters
│   ├── Extensions
│   ├── Importers
│   └── Models
│
├── ReserveWorkbookGenerator.Console
│
└── ReserveWorkbookGenerator.Tests
```

---

# Responsibilities

## Importers

Importers read reserve study data from external sources.

Current implementation:

- JsonComponentImporter

Output:

- List<ReserveComponent>

---

## Models

Models represent business entities.

Current models include:

- ReserveComponent
- ReserveScheduleRow
- ReserveSettings
- ProjectionSettings
- ReserveProjectionYear

Models contain data but very little business logic.

---

## Calculators

Calculators perform individual business calculations.

Each calculator has one responsibility.

Current calculators:

- FfbCalculator
- AllocationCalculator
- AnnualContributionCalculator
- ComponentAgingCalculator

Every calculator exposes a single `Execute()` method.

---

## ReserveEngine

The ReserveEngine is responsible for building a reserve schedule for a single budget year.

Workflow:

```text
Reserve Components
        │
        ▼
ReserveScheduleBuilder
        │
        ▼
FfbCalculator
        │
        ▼
AllocationCalculator
        │
        ▼
AnnualContributionCalculator
        │
        ▼
Reserve Schedule
```

The ReserveEngine orchestrates calculations but performs no calculations itself.

---

## ProjectionEngine

The ProjectionEngine is responsible for projecting reserve pool balances through time.

Current capabilities:

- Calculate one budget year
- Roll forward to the next year
- Generate multi-year financial projections

Workflow:

```text
Beginning Pool
        │
        ▼
Annual Contributions
        │
        ▼
Interest
        │
        ▼
Reserve Expenditures
        │
        ▼
Ending Pool
```

The ProjectionEngine manages time and financial projections. It does not perform reserve calculations.

---

## Exporters

Exporters convert business data into deliverables.

Current implementation:

- ExcelWorkbookExporter

Future exporters may include:

- PDF
- HTML
- Dashboard
- Board Reports

---

# Design Principles

## Single Responsibility

Each class performs one task.

Examples:

- FfbCalculator calculates FFB.
- AllocationCalculator allocates the reserve pool.
- ProjectionEngine projects financial years.

---

## Composition

Engines coordinate calculators.

Calculators never call other calculators.

---

## Separation of Concerns

Business calculations are isolated from:

- File import
- Excel generation
- Console output
- User interface

---

## Immutable Source Data

Imported reserve components represent the original reserve study.

Projection calculations operate on cloned components, preserving the original study.

---

# Current Workflow

```text
Import Reserve Study
        │
        ▼
Reserve Components
        │
        ▼
ReserveEngine
        │
        ▼
Reserve Schedule
        │
        ▼
ProjectionEngine
        │
        ▼
Financial Projection
        │
        ▼
Excel Workbook
```

---

# Planned Evolution

The architecture is intentionally modular.

Future enhancements include:

- Dynamic projection
- Inflation adjustments
- Component replacement events
- Interest allocation
- Multiple funding methodologies
- What-if analysis
- Dashboard reporting

These features should be implemented without changing the core architecture.

---

# Guiding Philosophy

The objective of this project is not to reproduce commercial reserve study software.

The objective is to provide a transparent, engineering-based reserve planning system that:

- separates calculations from presentation,
- supports pooled reserve funding,
- remains understandable by Board members,
- and can evolve as reserve funding methodologies improve.