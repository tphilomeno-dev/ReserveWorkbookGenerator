# Grand Cove Reserve Funding Methodology

**Project:** ReserveWorkbookGenerator  
**Version:** Draft 1.0  
**Last Updated:** July 2026

---

# Purpose

The purpose of the Grand Cove Reserve Funding Methodology is to present a reserve schedule that is familiar to condominium owners while accurately reflecting a modern pooled reserve funding strategy.

Traditional component reserve schedules tracked separate reserve "buckets" for each reserve component. Under pooled funding there is only one reserve account. This methodology analytically allocates the pooled balance among reserve components to improve transparency without implying that separate bank accounts exist.

The resulting reserve schedule allows owners to understand:

- How reserve funds are allocated
- Why annual reserve contributions are required
- How future replacement obligations are funded
- How reserve funding decisions are made

This methodology is intended to bridge the gap between traditional component reserve schedules and modern pooled reserve funding.

---

# Design Goals

The Reserve Workbook has several primary design goals.

- Maintain a traditional reserve schedule familiar to owners.
- Preserve the financial integrity of pooled reserve funding.
- Base reserve funding on engineering principles rather than arbitrary percentages.
- Produce calculations that are transparent and auditable.
- Minimize manual calculations.
- Generate a reserve schedule that Board members can easily explain to owners.
- Separate business rules from workbook presentation.
- Allow future reserve studies to be incorporated with minimal changes.

---

# Guiding Principles

## Principle 1 — There Is Only One Reserve Account

The Association maintains a single pooled reserve account.

Reserve components do **not** represent separate bank accounts.

Component balances shown in the workbook are analytical allocations only.

---

## Principle 2 — Beginning Allocation Is Recalculated Every Budget Year

Beginning Allocation is **never carried forward** from the previous year's analytical allocation.

Instead, it is recalculated annually using:

- Current reserve pool balance
- Current reserve study
- Current Fully Funded Balance (FFB) weights

This ensures the reserve schedule always reflects current engineering conditions.

---

## Principle 3 — Fully Funded Balance Determines Funding Priority

The Fully Funded Balance (FFB) represents the ideal reserve amount for each component based upon its age and remaining useful life.

FFB is used to determine each component's proportional share of the pooled reserve.

---

## Principle 4 — Engineering Drives The Funding Model

Reserve studies provide engineering recommendations.

The Board establishes funding policy.

The workbook combines both into a transparent reserve schedule.

---

## Principle 5 — Every Calculation Must Be Explainable

If a reserve calculation cannot be explained in plain English to a unit owner, it should not be included in the workbook.

Transparency is a primary design objective.

---

# Funding Model

The Reserve Workbook implements a Hybrid FFB Funding Model.

The model combines the strengths of both traditional component funding and pooled reserve funding.

## Traditional Component Funding

Advantages

- Easy to understand
- Individual component balances
- Familiar reserve schedule

Disadvantages

- Artificial reserve buckets
- Difficult to manage cash flow
- Can produce inefficient reserve balances

---

## Pooled Funding

Advantages

- Single reserve account
- Maximum financial flexibility
- Better cash management

Disadvantages

- Difficult for owners to understand
- No visible component balances
- Reserve studies often difficult to interpret

---

## Hybrid FFB Funding

The Hybrid FFB Funding Model combines both approaches.

Financial Characteristics

- One pooled reserve account
- No individual reserve bank accounts

Reporting Characteristics

- Component reserve schedule
- Analytical beginning allocations
- FFB based weighting
- Transparent funding calculations

---

# Annual Budget Process

Each budget year begins by determining the Association's actual reserve balance.

The reserve study is then updated using current information.

The workbook performs the following calculations:

1. Calculate Remaining Life
2. Calculate Fully Funded Balance (FFB)
3. Calculate FFB Weight
4. Allocate Beginning Reserve Pool
5. Calculate Annual Contributions
6. Allocate Interest
7. Apply Reserve Expenditures
8. Calculate Ending Allocation
9. Calculate Fund Ratio

The resulting schedule becomes the Association's reserve funding plan for the coming fiscal year.

---

# Reserve Schedule Columns

The Reserve Schedule currently contains the following columns.

| Column | Purpose |
|---------|---------|
| ID | Component Identifier |
| Category | Reserve Category |
| Reserve Component | Component Description |
| Last Replaced | Last Replacement Year |
| Useful Life | Expected Service Life |
| Remaining Life | Years Until Replacement |
| Replacement Cost | Current Replacement Cost |
| Replacement Year | Planned Replacement Year |
| Beginning Allocation | Analytical allocation of pooled reserve |
| Remaining Required | Additional funding required |
| % Total Replacement Cost | Component percentage of total replacement cost |
| Fully Funded Balance | Current engineering funding target |
| % Total FFB | Component percentage of total FFB |
| Annual Contribution | Annual reserve contribution |
| Interest Allocation | Share of annual reserve interest |
| Reserve Expenditure | Planned reserve spending |
| Ending Allocation | End-of-year analytical allocation |
| Fund Ratio | Beginning Allocation ÷ Fully Funded Balance |
| Monthly Contribution | Monthly reserve contribution |
| Monthly CPU | Monthly contribution per unit |
| Comments | Notes |

---

# Definitions

## Fully Funded Balance (FFB)

The ideal reserve amount that should exist today for a reserve component based upon its age and remaining useful life.

---

## Beginning Allocation

The analytical allocation of the Association's pooled reserve balance among reserve components.

Beginning Allocation does **not** represent separate reserve accounts.

---

## Remaining Required

The additional reserve funding required for a component.

**Note:** The exact calculation methodology is currently under review.

---

## Fund Ratio

The ratio of Beginning Allocation to Fully Funded Balance.

Fund Ratio provides an indication of reserve funding strength.

---

## Component Funding

A reserve funding model that maintains separate reserve balances for each component.

---

## Pooled Funding

A reserve funding model that maintains a single reserve account for all reserve expenditures.

---

## Hybrid FFB Funding

The funding methodology implemented by this project.

It combines pooled reserve funding with analytical component allocations to improve transparency.

---

# Future Enhancements

Planned enhancements include:

- Automatic Remaining Life calculations
- Remaining Life override capability
- Annual inflation adjustments
- Interest allocation models
- Thirty-year reserve projections
- Dashboard reporting
- Board summary reports
- Owner funding summaries
- Multiple reserve funding methodologies
- Cash Flow funding comparisons

---

# Guiding Philosophy

The objective of this project is **not** to reproduce reserve study software.

The objective is to produce a reserve funding workbook that:

- follows sound engineering principles,
- preserves the flexibility of pooled funding,
- provides complete financial transparency,
- and can be easily understood by condominium owners and Board members.

Every calculation implemented by the Reserve Workbook should support those objectives.