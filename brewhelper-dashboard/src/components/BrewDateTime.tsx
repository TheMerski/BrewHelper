import * as React from "react";
import { makeStyles } from "@material-ui/core/styles";
import LaunchIcon from "@material-ui/icons/Launch";

const useStyles = makeStyles({
  link: {
    textDecoration: "none",
  },
  icon: {
    width: "0.5em",
    paddingLeft: 2,
  },
});

/**
 * returns true if startDate is more than 24h before endDate
 * @param startDate start Date
 * @param endDate end Date
 */
function showDays(startDate: Date, endDate: Date): boolean {
  const oneDay = 60 * 60 * 24 * 1000;
  const endDateMinusDay = new Date(endDate.getTime() - oneDay);
  // More than 24h
  if (startDate > endDateMinusDay) {
    return true;
  }
  return false;
}

function daysBetween(startDate: Date, endDate: Date): number {
  return Math.ceil(Math.abs(endDate.getTime() - startDate.getTime()) / (1000 * 3600 * 24));
}

const BrewDateTime: React.FC<{
  record?: any;
  startSource: any;
  endSource: any;
}> = ({ record = {}, startSource, endSource }) => {
  const classes = useStyles();
  const startDate: Date = new Date(record[startSource]);
  const endDate: Date = new Date(record[endSource]);
  const now = new Date(Date.now());
  if (endDate != null && endDate <= new Date(Date.now())) {
    if (showDays(startDate, endDate)) {
      return (
        <p>
          <span>
            Ended on {endDate.getDay()}-{endDate.getMonth()}-{endDate.getFullYear()}
          </span>
          <br />
          <span>Lasted for {daysBetween(startDate, endDate)} days</span>
        </p>
      );
    }
    return (
      <p>
        <span>
          Ended on {endDate.getDay()}-{endDate.getMonth()}-{endDate.getFullYear()}
        </span>
        <span>
          <br />
          Lasted for {new Date(endDate.getTime() - startDate.getTime()).getHours()} hours
        </span>
      </p>
    );
  } else {
    if (showDays(startDate, now)) {
      return (
        <p>
          Started on {startDate.getDay()}-{startDate.getMonth()}-{startDate.getFullYear()}
        </p>
      );
    }
    return (
      <p>
        Started on {startDate.getDay()}-{startDate.getMonth()}-{startDate.getFullYear()}
      </p>
    );
  }
};

export default BrewDateTime;
