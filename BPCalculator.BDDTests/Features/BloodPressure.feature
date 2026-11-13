
Feature: Blood pressure category calculation
  As a user of the Blood Pressure Calculator
  I want my blood pressure readings categorised
  So that I can understand the category of my reading

  Scenario: Identify high blood pressure
    Given the systolic pressure is 145
    And the diastolic pressure is 85
    When the blood pressure category is calculated
    Then the category should be High

  Scenario: Identify pre-high blood pressure
    Given the systolic pressure is 125
    And the diastolic pressure is 75
    When the blood pressure category is calculated
    Then the category should be PreHigh

  Scenario: Identify ideal blood pressure
    Given the systolic pressure is 100
    And the diastolic pressure is 70
    When the blood pressure category is calculated
    Then the category should be Ideal

  Scenario: Identify low blood pressure
    Given the systolic pressure is 80
    And the diastolic pressure is 50
    When the blood pressure category is calculated
    Then the category should be Low


  Scenario Outline: Verify blood pressure category boundaries
    Given the systolic pressure is <systolic>
    And the diastolic pressure is <diastolic>
    When the blood pressure category is calculated
    Then the category should be <category>

    Examples:
      | systolic | diastolic | category |
      | 140      | 85        | High     |
      | 139      | 85        | PreHigh  |
      | 120      | 75        | PreHigh  |
      | 119      | 75        | Ideal    |
      | 90       | 59        | Ideal    |
      | 89       | 59        | Low      |
      | 110      | 90        | High     |
      | 110      | 80        | PreHigh  |
