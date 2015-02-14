<?php

class Guest {
    private $firstName;
    private $lastName;
    private $id;
    
    public function __construct($firstName, $lastName, $id) {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setId($id);
    }
    
    public function getFirstName() {
        return $this->firstName;
    }

    public function setFirstName($firstName) {
        if (!isset($firstName) || empty($firstName)) {
            trigger_error("Unvalid name!");
        }
        $this->firstName = $firstName;
    }
    
    public function getLastName() {
        return $this->lastName;
    }
    
    public function setLastName($lastName) {
        if (!isset($lastName) || empty($lastName)) {
            trigger_error("Unvalid name!");
        }
        $this->lastName = $lastName;
    }

    public function getId() {
        return $this->id;
    }
    
    public function setId($id) {
        if (strlen($id) != 10 || !is_numeric($id)) {
            trigger_error("Invalid ID!");
        }
        $this->id = $id;
    }
    
    public function __toString() {
        return $this->getFirstName() . " " . $this->getLastName();
    }
}