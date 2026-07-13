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