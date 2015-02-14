<?php

abstract class Room implements iReservable {
    private $roomType;
    private $hasRestRoom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $extras;
    private $price;
    private $reservations = [];
    
    public function __construct($roomType, $restRoom, $balcony, $bedCount,
            $roomNumber, $extras, $price) {
        $this->roomType = $roomType;
        $this->hasRestRoom = $restRoom;
        $this->hasBalcony = $balcony;
        $this->bedCount = $bedCount;
        $this->setRoomNumber($roomNumber);
        $this->extras = $extras;
        $this->setPrice($price);
    }
    
    public function getRoomType() {
        switch ($this->roomType) {
            case 1: return 'Standart'; 
                break;
            case 2: return 'Gold';
                break;
            case 3: return'Diamond';
                break;
            default:
                break;
        }
    }

    public function getHasRestRoom() {
        if ($this->hasRestRoom) {
        return 'has restroom';
        }
        
        return 'no restroom';
    }

    public function getHasBalcony() {
        if ($this->hasBalcony) {
        return 'has balcony';
        }
        
        return 'no balcony';
    }

    public function getBedCount() {
        return $this->bedCount;
    }

    public function getRoomNumber() {
        return $this->roomNumber;
    }

    public function setRoomNumber($roomNumber) {
        if (!is_numeric($roomNumber) || $roomNumber <= 0) {
            trigger_error("Room number must be positive number!");
        }
        $this->roomNumber = $roomNumber;
    }

    public function getExtras() {
        return $this->extras;
    }

    public function getPrice() {
        return $this->price;
    }

    public function setPrice($price) {
        if (!is_numeric($price) || $price <= 0) {
            trigger_error("Price must be positive number!");
        }
        $this->price = $price;
    }
    
    public function getReservations() {
        return $this->reservations;
    }

    public function setReservations($reservations) {
        $this->reservations = $reservations;
    }
    
    public function addReservation(Reservation $reservation) {
        $startDate = $reservation->getStartDate();
        $endDate = $reservation->getEndDate();
        
        foreach ($this->reservations as $placedReservations) {
            if (($startDate >= $placedReservations->getStartDate() &&
                    $startDate <= $placedReservations->getEndDate() &&
                    $endDate >= $placedReservations->getStartDate() &&
                    $endDate <= $placedReservations->getEndDate()) ||
                    ($startDate <= $placedReservations->getStartDate() &&
                    $endDate >= $placedReservations->getEndDate())) {
                throw new EReservationException();
            }
        }
        
        $this->reservations[] = $reservation;
    }

    public function removeReservation(Reservation $reservation) {
        foreach ($this->reservations as $key=>$placedReservation) {
            if ($placedReservation === $reservation) {
                unset($this->reservations[$key]);
            }
        }
    }
    
    public function __toString() {
        $roomInfo = "Room number: " . $this->getRoomNumber() . "</br>" .
                "Room type: " . $this->getRoomType() . "</br>"  .
                "Restroom: " . $this->getHasRestRoom() . "</br>" . 
                "Balcony: " . $this->getHasBalcony() . "</br>" .
                "Bed count: " . $this->getBedCount() . "</br>" .
                "Extras: " . $this->getExtras() .
                "</br>Reservations:</br>";
        
        foreach ($this->reservations as $reservation) {
            $roomInfo .= $reservation . "</br>";
        }
        
        return$roomInfo;
    }
}
