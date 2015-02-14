<?php

class EReservationException extends Exception {
    public function __construct() {
        parent::__construct(" is occupied for this period.", 101);
    }
}
