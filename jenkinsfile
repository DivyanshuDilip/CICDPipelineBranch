pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = "${env.WORKSPACE}"  // Fix for missing HOME variable
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/DivyanshuDilip/CICDPipelineBranch.git', branch: 'CICDIntegration'
            }
        }

        stage('Restore') {
            steps {
                dir('PipelineByGithubAction') {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir('PipelineByGithubAction') {
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                dir('PipelineByGithubAction') {
                    sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'Note: TRX format is not directly supported by the junit plugin. You may need to convert to JUnit XML if publishing results to Jenkins.'
            }
        }

    }
}
