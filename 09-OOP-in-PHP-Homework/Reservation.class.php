<?php

class Reservation {
    private $startDate;
    private $endDate;
    private $guest;
    
    public function __construct($startDate, $endDate, Guest $guest) {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }

    public function getStartDate() {
        return $this->startDate;
    }
    
    public function setStartDate($startDate) {
        if ($startDate < strtotime("now")) {
            trigger_error("Invalid start reservation date!");
        }
        $this->startDate = $startDate;
    }

    public function getEndDate() {
        return $this->endDate;
    }
    
    public function setEndDate($endDate) {
        if ($this->getStartDate() > $endDate) {
            trigger_error("Invalid end reservation date!");
        }
        $this->endDate = $endDate;
    }

    public function getGuest() {
        return $this->guest;
    }
    
    public function setGuest($guest) {
        $this->guest = $guest;
    }
    
    public function __toString() {
        $startDate = date("d-m-Y", $this->getStartDate());
        $endDate = date("d-m-Y", $this->getEndDate());
        return "<strong>" . $this->getGuest() . "</strong> " .
            "from <time>" . $startDate . "</time> to <time>" .
            $endDate . "</time>!";
    }
}
