#!/bin/bash
for i in 1000 1400 1800 2200 2600
do
  echo "start: $(date)"
  echo "doing rate $i"
  echo "GET https://stressthecloud-functions.azurewebsites.net/api/SimpleJson" | vegeta attack -duration=600s  -rate $i -timeout 120s | tee resultsSimpleJson_$1_r$i.bin | vegeta report
  cat resultsSimpleJson_$1_r$i.bin  | vegeta plot > resultsSimpleJson_$1_r$i.html
  echo "finish: $(date)"
  echo "sleeping 5 minutes"
  sleep 5m
done
